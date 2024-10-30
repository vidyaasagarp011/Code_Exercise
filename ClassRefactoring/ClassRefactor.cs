using System;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African, European
    }

    public enum SwallowLoad
    {
        None, Coconut
    }

    public class SwallowFactory
    {
        public Swallow GetSwallow(SwallowType swallowType, SwallowLoad load)
        {
            return swallowType switch
            {
                SwallowType.African => new AfricanSwallow(load),
                SwallowType.European => new EuropeanSwallow(load),
                _ => throw new ArgumentException(ExceptionConstants.InValidShallowType, nameof(SwallowType))
            };
        }

        public abstract class Swallow
        {
            public SwallowLoad Load { get; private set; }

            protected Swallow(SwallowLoad load)
            {
                Load = load;
            }
            public abstract double GetAirspeedVelocity();

        }

        // Derived class for African Swallow
        public class AfricanSwallow : Swallow
        {
            public AfricanSwallow(SwallowLoad load) : base(load) { }

            public override double GetAirspeedVelocity()
            {
                return Load switch
                {
                    SwallowLoad.None => 22,
                    SwallowLoad.Coconut => 18,
                    _ => throw new InvalidOperationException(ExceptionConstants.InValidLoad)
                };
            }
        }

        // Derived class for European Swallow
        public class EuropeanSwallow : Swallow
        {
            public EuropeanSwallow(SwallowLoad load) : base(load) { }

            public override double GetAirspeedVelocity()
            {
                return Load switch
                {
                    SwallowLoad.None => 20,
                    SwallowLoad.Coconut => 16,
                    _ => throw new InvalidOperationException(ExceptionConstants.InValidLoad)
                };
            }
        }
    }
}