using toofz.NecroDancer.Data;
using Xunit;

namespace toofz.NecroDancer.Tests.Data
{
    public class BouncerTests
    {
        public class Constructor
        {
            [DisplayFact(nameof(Bouncer))]
            public void ReturnsBouncer()
            {
                // Arrange -> Act
                var bouncer = new Bouncer();

                // Assert
                Assert.IsAssignableFrom<Bouncer>(bouncer);
            }
        }

        public class MinProperty
        {
            [DisplayFact(nameof(Bouncer.Min))]
            public void GetsAndSetsMin()
            {
                // Arrange
                var bouncer = new Bouncer();
                var min = 2.4;

                // Act
                bouncer.Min = min;
                var min2 = bouncer.Min;

                // Assert
                Assert.Equal(min, min2);
            }
        }

        public class MaxProperty
        {
            [DisplayFact(nameof(Bouncer.Max))]
            public void GetsAndSetsMax()
            {
                // Arrange
                var bouncer = new Bouncer();
                var max = 2.4;

                // Act
                bouncer.Max = max;
                var max2 = bouncer.Max;

                // Assert
                Assert.Equal(max, max2);
            }
        }

        public class PowerProperty
        {
            [DisplayFact(nameof(Bouncer.Power))]
            public void GetsAndSetsPower()
            {
                // Arrange
                var bouncer = new Bouncer();
                var power = 2.4;

                // Act
                bouncer.Power = power;
                var power2 = bouncer.Power;

                // Assert
                Assert.Equal(power, power2);
            }
        }

        public class StepsProperty
        {
            [DisplayFact(nameof(Bouncer.Steps))]
            public void GetsAndSetsSteps()
            {
                // Arrange
                var bouncer = new Bouncer();
                var steps = 15;

                // Act
                bouncer.Steps = steps;
                var steps2 = bouncer.Steps;

                // Assert
                Assert.Equal(steps, steps2);
            }
        }
    }
}
