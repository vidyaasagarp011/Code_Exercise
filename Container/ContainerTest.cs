using Xunit;
using FluentAssertions;
using System;

namespace DeveloperSample.Container
{
    public interface IContainerTestInterface
    {
        void DoSomething();
    }

    public class ContainerTestClass : IContainerTestInterface
    {
        public void DoSomething() { }
    }

    public class ContainerTest
    {
        [Fact]
        public void CanBindAndGetService()
        {
            // Arrange
            var container = new Container();
            container.Bind(typeof(IContainerTestInterface), typeof(ContainerTestClass));

            // Act
            var testInstance = container.Get<IContainerTestInterface>();

            // Assert
            testInstance.Should().BeOfType<ContainerTestClass>();
        }

        [Fact]
        public void ThrowsExceptionWhenBindingNonInterface()
        {
            // Arrange
            var container = new Container();
            var nonInterfaceType = typeof(ContainerTestClass);

            // Act
            Action act = () => container.Bind(nonInterfaceType, nonInterfaceType);

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage(ContainerMessageConstants.InterfaceTypeNotAnInterfaceError);
        }

    }
}