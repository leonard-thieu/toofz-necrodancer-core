using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using toofz.NecroDancer.Data;

namespace toofz.NecroDancer.Tests.Data
{
    class EnemyTests
    {
        [TestClass]
        public class Constructor_String_Int32
        {
            [TestMethod]
            public void NameIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                string name = null;
                var type = 1;

                // Act -> Assert
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    new Enemy(name, type);
                });
            }

            [TestMethod]
            public void TypeIsLessThan1_ThrowsArgumentOutOfRangeException()
            {
                // Arrange
                var name = "myName";
                var type = 0;

                // Act -> Assert
                Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                {
                    new Enemy(name, type);
                });
            }

            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange
                var name = "myName";
                var type = 1;

                // Act
                var enemy = new Enemy(name, type);

                // Assert
                Assert.IsInstanceOfType(enemy, typeof(Enemy));
            }

            [TestMethod]
            public void SetsName()
            {
                // Arrange
                var name = "myName";
                var type = 1;
                var enemy = new Enemy(name, type);

                // Act
                var name2 = enemy.Name;

                // Assert
                Assert.AreEqual(name, name2);
            }

            [TestMethod]
            public void SetsType()
            {
                // Arrange
                var name = "myName";
                var type = 1;
                var enemy = new Enemy(name, type);

                // Act
                var type2 = enemy.Type;

                // Assert
                Assert.AreEqual(type, type2);
            }
        }

        [TestClass]
        public class LevelEditorProperty
        {
            [TestMethod]
            public void Default_ReturnsTrue()
            {
                // Arrange
                var name = "myName";
                var type = 1;
                var enemy = new Enemy(name, type);

                // Act
                var levelEditor = enemy.LevelEditor;

                // Assert
                Assert.IsTrue(levelEditor);
            }

            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var name = "myName";
                var type = 1;
                var enemy = new Enemy(name, type);
                var levelEditor = false;

                // Act
                enemy.LevelEditor = levelEditor;
                var levelEditor2 = enemy.LevelEditor;

                // Assert
                Assert.AreEqual(levelEditor, enemy.LevelEditor);
            }
        }

        [TestClass]
        public class SpriteSheetProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var name = "myName";
                var type = 1;
                var enemy = new Enemy(name, type);
                var spriteSheet = new SpriteSheet("myPath");

                // Act
                enemy.SpriteSheet = spriteSheet;
                var spriteSheet2 = enemy.SpriteSheet;

                // Assert
                Assert.AreEqual(spriteSheet, spriteSheet2);
            }
        }

        [TestClass]
        public class FramesProperty
        {
            [TestMethod]
            public void ReturnsFrames()
            {
                // Arrange
                var name = "myName";
                var type = 1;
                var enemy = new Enemy(name, type);

                // Act
                var frames = enemy.Frames;

                // Assert
                Assert.IsInstanceOfType(frames, typeof(ICollection<Frame>));
            }
        }

        [TestClass]
        public class ShadowProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var name = "myName";
                var type = 1;
                var enemy = new Enemy(name, type);
                var shadow = new Shadow("myPath");

                // Act
                enemy.Shadow = shadow;
                var shadow2 = enemy.Shadow;

                // Assert
                Assert.AreEqual(shadow, shadow2);
            }
        }

        [TestClass]
        public class StatsProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var name = "myName";
                var type = 1;
                var enemy = new Enemy(name, type);
                var stats = new Stats();

                // Act
                enemy.Stats = stats;
                var stats2 = enemy.Stats;

                // Assert
                Assert.AreEqual(stats, stats2);
            }
        }

        [TestClass]
        public class OptionalStatsProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var name = "myName";
                var type = 1;
                var enemy = new Enemy(name, type);
                var optionalStats = new OptionalStats();

                // Act
                enemy.OptionalStats = optionalStats;
                var optionalStats2 = enemy.OptionalStats;

                // Assert
                Assert.AreEqual(optionalStats, optionalStats2);
            }
        }

        [TestClass]
        public class BouncerProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var name = "myName";
                var type = 1;
                var enemy = new Enemy(name, type);
                var bouncer = new Bouncer();

                // Act
                enemy.Bouncer = bouncer;
                var bouncer2 = enemy.Bouncer;

                // Assert
                Assert.AreEqual(bouncer, bouncer2);
            }
        }

        [TestClass]
        public class TweensProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var name = "myName";
                var type = 1;
                var enemy = new Enemy(name, type);
                var tweens = new Tweens();

                // Act
                enemy.Tweens = tweens;
                var tweens2 = enemy.Tweens;

                // Assert
                Assert.AreEqual(tweens, tweens2);
            }
        }

        [TestClass]
        public class ParticleProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var name = "myName";
                var type = 1;
                var enemy = new Enemy(name, type);
                var particle = new Particle();

                // Act
                enemy.Particle = particle;
                var particle2 = enemy.Particle;

                // Assert
                Assert.AreEqual(particle, particle2);
            }
        }

        [TestClass]
        public class DisplayNameProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var name = "myName";
                var type = 1;
                var enemy = new Enemy(name, type);
                var displayName = "White Armadillo";

                // Act
                enemy.DisplayName = displayName;
                var displayName2 = enemy.DisplayName;

                // Assert
                Assert.AreEqual(displayName, displayName2);
            }
        }
    }
}
