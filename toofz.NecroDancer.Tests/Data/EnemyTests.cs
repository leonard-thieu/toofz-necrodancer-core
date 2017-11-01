using System;
using System.Collections.Generic;
using toofz.NecroDancer.Data;
using Xunit;

namespace toofz.NecroDancer.Tests.Data
{
    public class EnemyTests
    {
        public class Constructor_String_Int32
        {
            [Fact]
            public void NameIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                string name = null;
                var type = 1;

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    new Enemy(name, type);
                });
            }

            [Fact]
            public void TypeIsLessThan1_ThrowsArgumentOutOfRangeException()
            {
                // Arrange
                var name = "myName";
                var type = 0;

                // Act -> Assert
                Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    new Enemy(name, type);
                });
            }

            [Fact]
            public void ReturnsInstance()
            {
                // Arrange
                var name = "myName";
                var type = 1;

                // Act
                var enemy = new Enemy(name, type);

                // Assert
                Assert.IsAssignableFrom<Enemy>(enemy);
            }

            [Fact]
            public void SetsName()
            {
                // Arrange
                var name = "myName";
                var type = 1;
                var enemy = new Enemy(name, type);

                // Act
                var name2 = enemy.Name;

                // Assert
                Assert.Equal(name, name2);
            }

            [Fact]
            public void SetsType()
            {
                // Arrange
                var name = "myName";
                var type = 1;
                var enemy = new Enemy(name, type);

                // Act
                var type2 = enemy.Type;

                // Assert
                Assert.Equal(type, type2);
            }
        }

        public class LevelEditorProperty
        {
            [Fact]
            public void Default_ReturnsTrue()
            {
                // Arrange
                var name = "myName";
                var type = 1;
                var enemy = new Enemy(name, type);

                // Act
                var levelEditor = enemy.LevelEditor;

                // Assert
                Assert.True(levelEditor);
            }

            [Fact]
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
                Assert.Equal(levelEditor, enemy.LevelEditor);
            }
        }

        public class SpriteSheetProperty
        {
            [Fact]
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
                Assert.Equal(spriteSheet, spriteSheet2);
            }
        }

        public class FramesProperty
        {
            [Fact]
            public void ReturnsFrames()
            {
                // Arrange
                var name = "myName";
                var type = 1;
                var enemy = new Enemy(name, type);

                // Act
                var frames = enemy.Frames;

                // Assert
                Assert.IsAssignableFrom<ICollection<Frame>>(frames);
            }
        }

        public class ShadowProperty
        {
            [Fact]
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
                Assert.Equal(shadow, shadow2);
            }
        }

        public class StatsProperty
        {
            [Fact]
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
                Assert.Equal(stats, stats2);
            }
        }

        public class OptionalStatsProperty
        {
            [Fact]
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
                Assert.Equal(optionalStats, optionalStats2);
            }
        }

        public class BouncerProperty
        {
            [Fact]
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
                Assert.Equal(bouncer, bouncer2);
            }
        }

        public class TweensProperty
        {
            [Fact]
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
                Assert.Equal(tweens, tweens2);
            }
        }

        public class ParticleProperty
        {
            [Fact]
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
                Assert.Equal(particle, particle2);
            }
        }

        public class DisplayNameProperty
        {
            [Fact]
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
                Assert.Equal(displayName, displayName2);
            }
        }
    }
}
