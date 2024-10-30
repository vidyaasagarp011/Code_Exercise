using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DeveloperSample.Container
{
    public class Container : IContainer
    {
        private readonly Dictionary<Type, Type> _typeMaps = new Dictionary<Type, Type>();
        private readonly Dictionary<Type, object> _instances = new Dictionary<Type, object>();

        public void Bind(Type interfaceType, Type implementationType)
        {
            if (!interfaceType.IsInterface)
            {
                throw new ArgumentException(ContainerMessageConstants.InterfaceTypeNotAnInterfaceError);
            }

            if (!interfaceType.IsAssignableFrom(implementationType))
            {
                throw new ArgumentException(ContainerMessageConstants.ImplementationTypeDoesNotImplementError);
            }

            _typeMaps[interfaceType] = implementationType;
        }

        public T Get<T>()
        {
            var type = typeof(T);
            return (T)Get(type);
        }

        private object Get(Type type)
        {
            // Checking for any instance already exists
            if (_instances.TryGetValue(type, out var instance))
            {
                return instance;
            }

            // If not found, resolving the type
            if (_typeMaps.TryGetValue(type, out var implementationType))
            {
                // Create a new instance
                instance = Activator.CreateInstance(implementationType);
                _instances[type] = instance;
                return instance;
            }

            throw new InvalidOperationException(string.Format(ContainerMessageConstants.TypeNotRegisteredError, type.Name));
        }
    }
}