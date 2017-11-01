using toofz.NecroDancer.Data;
using Xunit;

namespace toofz.NecroDancer.Tests.Data
{
    public class BouncerTests
    {
        public class Constructor
        {
            [Fact]
            public void ReturnsInstance()
            {
                // Arrange -> Act
                var bouncer = new Bouncer();

                // Assert
                Assert.IsAssignableFrom<Bouncer>(bouncer);
            }
        }

        public class MinProperty
        {
            [Fact]
            public void GetSetBehavior()
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
            [Fact]
            public void GetSetBehavior()
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
            [Fact]
            public void GetSetBehavior()
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
            [Fact]
            public void GetSetBehavior()
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
