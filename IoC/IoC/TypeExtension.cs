using IoC.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IoC
{
    public static class TypeExtension
    {
       public static IEnumerable<PropertyInfo> GetImportedProperties(this Type type)
       {
            return type.GetProperties().Where(p => p.GetCustomAttribute<ImportAttribute>() != null);
       }

        public static bool HasImportedProperties(this Type type)
        {
            return type.GetImportedProperties().Any();
        }

        public static bool HasAtributes(this ImportConstructorAttribute constructor)
        {
            if (constructor == null)
            {
                return false;
            }
            return true;
        }
    }
}
