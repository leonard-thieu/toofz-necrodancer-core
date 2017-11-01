using System;
using System.Collections.Generic;
using toofz.NecroDancer.Replays;
using toofz.NecroDancer.Saves;
using Xunit;

namespace toofz.NecroDancer.Tests.Replays
{
    public class ReplayDataTests
    {
        public class Constructor
        {
            [Fact]
            public void ReturnsInstance()
            {
                // Arrange -> Act
                var replayData = new ReplayData();

                // Assert
                Assert.IsAssignableFrom<ReplayData>(replayData);
            }
        }

        public class KilledByProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var killedBy = "BOMB";

                // Act
                replayData.KilledBy = killedBy;
                var killedBy2 = replayData.KilledBy;

                // Assert
                Assert.Equal(killedBy, killedBy2);
            }
        }

        public class IsRemoteProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var isRemote = true;

                // Act
                replayData.IsRemote = isRemote;
                var isRemote2 = replayData.IsRemote;

                // Assert
                Assert.Equal(isRemote, isRemote2);
            }
        }

        public class VersionProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var version = 84;

                // Act
                replayData.Version = version;
                var version2 = replayData.Version;

                // Assert
                Assert.Equal(version, version2);
            }
        }

        public class StartZoneProperty
        {
            [Fact]
            public void Default_Returns1()
            {
                // Arrange
                var replayData = new ReplayData();

                // Act
                var startZone = replayData.StartZone;

                // Assert
                Assert.Equal(1, startZone);
            }

            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var startZone = 2;

                // Act
                replayData.StartZone = startZone;
                var startZone2 = replayData.StartZone;

                // Assert
                Assert.Equal(startZone, startZone2);
            }
        }

        public class StartCoinsProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var startCoins = 10;

                // Act
                replayData.StartCoins = startCoins;
                var startCoins2 = replayData.StartCoins;

                // Assert
                Assert.Equal(startCoins, startCoins2);
            }
        }

        public class HasBroadswordProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var hasBroadsword = true;

                // Act
                replayData.HasBroadsword = hasBroadsword;
                var hasBroadsword2 = replayData.HasBroadsword;

                // Assert
                Assert.Equal(hasBroadsword, hasBroadsword2);
            }
        }

        public class IsHardcoreProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var isHardcore = true;

                // Act
                replayData.IsHardcore = isHardcore;
                var isHardcore2 = replayData.IsHardcore;

                // Assert
                Assert.Equal(isHardcore, isHardcore2);
            }
        }

        public class IsDailyProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var isDaily = true;

                // Act
                replayData.IsDaily = isDaily;
                var isDaily2 = replayData.IsDaily;

                // Assert
                Assert.Equal(isDaily, isDaily2);
            }
        }

        public class IsDancePadModeProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var isDancePadMode = true;

                // Act
                replayData.IsDancePadMode = isDancePadMode;
                var isDancePadMode2 = replayData.IsDancePadMode;

                // Assert
                Assert.Equal(isDancePadMode, isDancePadMode2);
            }
        }

        public class IsSeededProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var isSeeded = true;

                // Act
                replayData.IsSeeded = isSeeded;
                var isSeeded2 = replayData.IsSeeded;

                // Assert
                Assert.Equal(isSeeded, isSeeded2);
            }
        }

        public class RunProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var run = 1;

                // Act
                replayData.Run = run;
                var run2 = replayData.Run;

                // Assert
                Assert.Equal(run, run2);
            }
        }

        public class Unknown0
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var unknown0 = 1;

                // Act
                replayData.Unknown0 = unknown0;
                var unknown02 = replayData.Unknown0;

                // Assert
                Assert.Equal(unknown0, unknown02);
            }
        }

        public class Unknown2
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var unknown2 = 1;

                // Act
                replayData.Unknown2 = unknown2;
                var unknown22 = replayData.Unknown2;

                // Assert
                Assert.Equal(unknown2, unknown22);
            }
        }

        public class DurationProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var duration = TimeSpan.FromSeconds(15);

                // Act
                replayData.Duration = duration;
                var duration2 = replayData.Duration;

                // Assert
                Assert.Equal(duration, duration2);
            }
        }

        public class SongsProperty
        {
            [Fact]
            public void ReturnsSongs()
            {
                // Arrange
                var replayData = new ReplayData();

                // Act
                var songs = replayData.Songs;

                // Assert
                Assert.IsAssignableFrom<ICollection<Song>>(songs);
            }
        }

        public class SaveDataProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var saveData = new SaveData();

                // Act
                replayData.SaveData = saveData;
                var saveData2 = replayData.SaveData;

                // Assert
                Assert.Equal(saveData, saveData2);
            }
        }

        public class Seed
        {
            [Fact]
            public void NoSongs_ReturnsNull()
            {
                // Arrange
                var replayData = new ReplayData();

                // Act
                var seed = replayData.Seed;

                // Assert
                Assert.Null(seed);
            }

            [Theory]
            [InlineData(1580050689, 603033)]
            [InlineData(-2147483141, 89527)]
            public void ClassicFormat_ReturnsSeed(int levelSeed, int seed)
            {
                // Arrange
                var replayData = new ReplayData();
                var song = new Song { Seed = levelSeed };
                replayData.Songs.Add(song);

                // Act
                var seed2 = replayData.Seed;

                // Assert
                Assert.Equal(seed, seed2);
            }

            [Theory]
            [InlineData(1368956533, 25192)]
            [InlineData(58192416, 65)]
            [InlineData(1698929060, 68295)]
            public void AmplifiedFormat_ReturnsCorrectSeed(int levelSeed, int seed)
            {
                // Arrange
                var replayData = new ReplayData { Version = 84 };
                var song = new Song { Seed = levelSeed };
                replayData.Songs.Add(song);

                // Act
                var seed2 = replayData.Seed;

                // Assert
                Assert.Equal(seed, seed2);
            }
        }
    }
}
