using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperSample.Container
{
    public class ContainerMessageConstants
    {
        public const string InterfaceTypeNotAnInterfaceError = "The interfaceType must be an interface.";
        public const string ImplementationTypeDoesNotImplementError = "The implementationType must implement the interfaceType.";
        public const string TypeNotRegisteredError = "Type '{0}' is not registered in the container.";
    }
}
