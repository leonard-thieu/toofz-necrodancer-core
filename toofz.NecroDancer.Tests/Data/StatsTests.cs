using toofz.NecroDancer.Data;
using Xunit;

namespace toofz.NecroDancer.Tests.Data
{
    public class StatsTests
    {
        public class Constructor
        {
            [Fact]
            public void ReturnsInstance()
            {
                // Arrange -> Act
                var stats = new Stats();

                // Assert
                Assert.IsAssignableFrom<Stats>(stats);
            }
        }

        public class BeatsPerMoveProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var stats = new Stats();
                var beatsPerMove = 2;

                // Act
                stats.BeatsPerMove = beatsPerMove;
                var beatsPerMove2 = stats.BeatsPerMove;

                // Assert
                Assert.Equal(beatsPerMove, beatsPerMove2);
            }
        }

        public class CoinsToDropProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var stats = new Stats();
                var coinsToDrop = 5;

                // Act
                stats.CoinsToDrop = coinsToDrop;
                var coinsToDrop2 = stats.CoinsToDrop;

                // Assert
                Assert.Equal(coinsToDrop, coinsToDrop2);
            }
        }

        public class DamagePerHitProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var stats = new Stats();
                var damagePerHit = 2;

                // Act
                stats.DamagePerHit = damagePerHit;
                var damagePerHit2 = stats.DamagePerHit;

                // Assert
                Assert.Equal(damagePerHit, damagePerHit2);
            }
        }

        public class HealthProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var stats = new Stats();
                var health = 5;

                // Act
                stats.Health = health;
                var health2 = stats.Health;

                // Assert
                Assert.Equal(health, health2);
            }
        }

        public class MovementProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var stats = new Stats();
                var movement = "basicSeek";

                // Act
                stats.Movement = movement;
                var movement2 = stats.Movement;

                // Assert
                Assert.Equal(movement, movement2);
            }
        }

        public class PriorityProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var stats = new Stats();
                var priority = 10201102;

                // Act
                stats.Priority = priority;
                var priority2 = stats.Priority;

                // Assert
                Assert.Equal(priority, priority2);
            }
        }
    }
}
