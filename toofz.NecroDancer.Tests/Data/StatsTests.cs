using toofz.NecroDancer.Data;
using Xunit;

namespace toofz.NecroDancer.Tests.Data
{
    public class StatsTests
    {
        public class Constructor
        {
            [DisplayFact(nameof(Stats))]
            public void ReturnsStats()
            {
                // Arrange -> Act
                var stats = new Stats();

                // Assert
                Assert.IsAssignableFrom<Stats>(stats);
            }
        }

        public class BeatsPerMoveProperty
        {
            [DisplayFact(nameof(Stats.BeatsPerMove))]
            public void GetsAndSetsBeatsPerMove()
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
            [DisplayFact(nameof(Stats.CoinsToDrop))]
            public void GetsAndSetsCoinsToDrop()
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
            [DisplayFact(nameof(Stats.DamagePerHit))]
            public void GetsAndSetsDamagePerHit()
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
            [DisplayFact(nameof(Stats.Health))]
            public void GetsAndSetsHealth()
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
            [DisplayFact(nameof(Stats.Movement))]
            public void GetsAndSetsMovement()
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
            [DisplayFact(nameof(Stats.Priority))]
            public void GetsAndSetsPriority()
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
