using System;
using System.Collections.Generic;
using toofz.NecroDancer.Data;
using Xunit;

namespace toofz.NecroDancer.Tests.Data
{
    public class EnemyTests
    {
        public class Constructor
        {
            [DisplayFact(nameof(ArgumentNullException))]
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

            [DisplayFact(nameof(ArgumentOutOfRangeException))]
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

            [DisplayFact(nameof(Enemy))]
            public void ReturnsEnemy()
            {
                // Arrange
                var name = "myName";
                var type = 1;

                // Act
                var enemy = new Enemy(name, type);

                // Assert
                Assert.IsAssignableFrom<Enemy>(enemy);
            }

            [DisplayFact(nameof(Enemy.Name))]
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

            [DisplayFact(nameof(Enemy.Type))]
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
            [DisplayFact]
            public void NotSet_ReturnsDefault()
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

            [DisplayFact(nameof(Enemy.LevelEditor))]
            public void GetsAndSetsLevelEditor()
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
            [DisplayFact(nameof(Enemy.SpriteSheet))]
            public void GetsAndSetsSpriteSheet()
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
            [DisplayFact(nameof(Enemy.Frames))]
            public void GetsFrames()
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
            [DisplayFact(nameof(Enemy.Shadow))]
            public void GetsAndSetsShadow()
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
            [DisplayFact(nameof(Enemy.Stats))]
            public void GetsAndSetsStats()
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
            [DisplayFact(nameof(Enemy.OptionalStats))]
            public void GetsAndSetsOptionalStats()
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
            [DisplayFact(nameof(Enemy.Bouncer))]
            public void GetsAndSetsBouncer()
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
            [DisplayFact(nameof(Enemy.Tweens))]
            public void GetsAndSetsTweens()
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
            [DisplayFact(nameof(Enemy.Particle))]
            public void GetsAndSetsParticle()
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
            [DisplayFact(nameof(Enemy.DisplayName))]
            public void GetsAndSetsDisplayName()
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
