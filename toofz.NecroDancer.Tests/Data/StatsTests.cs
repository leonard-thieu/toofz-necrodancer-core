using Microsoft.VisualStudio.TestTools.UnitTesting;
using toofz.NecroDancer.Data;

namespace toofz.NecroDancer.Tests.Data
{
    class StatsTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange -> Act
                var stats = new Stats();

                // Assert
                Assert.IsInstanceOfType(stats, typeof(Stats));
            }
        }

        [TestClass]
        public class BeatsPerMoveProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var stats = new Stats();
                var beatsPerMove = 2;

                // Act
                stats.BeatsPerMove = beatsPerMove;
                var beatsPerMove2 = stats.BeatsPerMove;

                // Assert
                Assert.AreEqual(beatsPerMove, beatsPerMove2);
            }
        }

        [TestClass]
        public class CoinsToDropProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var stats = new Stats();
                var coinsToDrop = 5;

                // Act
                stats.CoinsToDrop = coinsToDrop;
                var coinsToDrop2 = stats.CoinsToDrop;

                // Assert
                Assert.AreEqual(coinsToDrop, coinsToDrop2);
            }
        }

        [TestClass]
        public class DamagePerHitProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var stats = new Stats();
                var damagePerHit = 2;

                // Act
                stats.DamagePerHit = damagePerHit;
                var damagePerHit2 = stats.DamagePerHit;

                // Assert
                Assert.AreEqual(damagePerHit, damagePerHit2);
            }
        }

        [TestClass]
        public class HealthProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var stats = new Stats();
                var health = 5;

                // Act
                stats.Health = health;
                var health2 = stats.Health;

                // Assert
                Assert.AreEqual(health, health2);
            }
        }

        [TestClass]
        public class MovementProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var stats = new Stats();
                var movement = "basicSeek";

                // Act
                stats.Movement = movement;
                var movement2 = stats.Movement;

                // Assert
                Assert.AreEqual(movement, movement2);
            }
        }

        [TestClass]
        public class PriorityProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var stats = new Stats();
                var priority = 10201102;

                // Act
                stats.Priority = priority;
                var priority2 = stats.Priority;

                // Assert
                Assert.AreEqual(priority, priority2);
            }
        }
    }
}
