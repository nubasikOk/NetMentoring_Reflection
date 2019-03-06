using System;
using IoC.Interfaces;

namespace IoC
{
    public class DIActivator:IActivator
    {
        public object CreateInstance(Type type, params object[] parameters)
        {
            return Activator.CreateInstance(type, parameters);
        }
    }
}
