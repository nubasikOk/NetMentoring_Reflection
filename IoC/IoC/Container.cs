using System;
using System.Collections.Generic;
using IoC.Interfaces;
using IoC.Attributes;
using System.Reflection;
using System.Linq;

namespace IoC
{
    public class Container
    {
        private readonly IDictionary<Type, Type> _typesDictionary;
        private readonly IActivator _activator;

        public Container(IActivator activator)
        {
            _activator = activator;
            _typesDictionary = new Dictionary<Type, Type>();
        }

        
        public void ReadAssembly(Assembly assembly)
        {
            var types = assembly.ExportedTypes;
            foreach (var type in types)
            {
                var constructorImportAttribute = type.GetCustomAttribute<ImportConstructorAttribute>();
                if (constructorImportAttribute.HasAtributes() ||  type.HasImportedProperties())
                {
                    _typesDictionary.Add(type, type);
                }

                var exportAttributes = type.GetCustomAttributes<ExportAttribute>();
                foreach (var exportAttribute in exportAttributes)
                {
                    if (exportAttribute.Contract != null)
                    {
                        foreach (var contract in exportAttribute.Contract)
                        {
                            _typesDictionary.Add(contract, type);
                        }
                    }
                    
                }
            }
        }

        private void ResolveProperties(Type type, object instance)
        {
            foreach (var property in type.GetImportedProperties())
            {
                var resolvedProperty = ConstructInstanceOfType(property.PropertyType);
                property.SetValue(instance, resolvedProperty);
            }
        }

        private object ConstructInstanceOfType(Type type)
        {
            if (!_typesDictionary.ContainsKey(type))
            {
                throw new Exception($"Can't create the instance of {type.FullName}. No mapping for the type!");
            }

            Type dependendType = _typesDictionary[type];
            ConstructorInfo constructorInfo = GetConstructor(dependendType);
            object instance = CreateFromConstructor(dependendType, constructorInfo);

            if (dependendType.GetCustomAttribute<ImportConstructorAttribute>() == null)
            {
                ResolveProperties(dependendType, instance);
            }            
            return instance;
        }

        private ConstructorInfo GetConstructor(Type type)
        {
            ConstructorInfo[] constructors = type.GetConstructors();

            if (constructors.Length == 0)
            {
                throw new Exception($"No constructors for the type {type.FullName}");
            }

            return constructors.First();
        }

        private object CreateFromConstructor(Type type, ConstructorInfo constructorInfo)
        {
            var parameters = constructorInfo.GetParameters();            
            var parametersInstances = parameters.Select(p => ConstructInstanceOfType(p.ParameterType));
            object instance = _activator.CreateInstance(type, parametersInstances.ToArray());
            return instance;
        }

        public void AddType(Type type)
        {
            _typesDictionary.Add(type, type);
        }

        public void AddType(Type type, Type baseType)
        {
            _typesDictionary.Add(baseType, type);
        }

        public object CreateInstance(Type type)
        {
            var instance = ConstructInstanceOfType(type);
            return instance;
        }

        public T CreateInstance<T>()
        {
            var type = typeof(T);
            var instance = (T)ConstructInstanceOfType(type);
            return instance;
        }

    }
}
