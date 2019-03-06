using IoC.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace IoC.Tests
{
    public static class TypeExtension
    {
       public static IEnumerable<PropertyInfo> GetImportedProperties(Type type)
        {
            return type.GetProperties().Where(p => p.GetCustomAttribute<ImportAttribute>() != null);
        }
    }
}
