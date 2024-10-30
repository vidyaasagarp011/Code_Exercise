using System;

namespace DeveloperSample.Container
{
    public interface IContainer
    {
        void Bind(Type interfaceType, Type implementationType);
        T Get<T>();
    }
}
