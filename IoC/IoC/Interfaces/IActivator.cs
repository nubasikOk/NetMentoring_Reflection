using System;

namespace IoC.Interfaces
{
    public interface IActivator
    {
        object CreateInstance(Type type, params object[] parameters);
    }
}
