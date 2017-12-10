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
            [DisplayFact(nameof(ReplayData))]
            public void ReturnsReplayData()
            {
                // Arrange -> Act
                var replayData = new ReplayData();

                // Assert
                Assert.IsAssignableFrom<ReplayData>(replayData);
            }
        }

        public class KilledByProperty
        {
            [DisplayFact(nameof(ReplayData.KilledBy))]
            public void GetsAndSetsKilledBy()
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
            [DisplayFact(nameof(ReplayData.IsRemote))]
            public void GetsAndSetsIsRemote()
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
            [DisplayFact(nameof(ReplayData.Version))]
            public void GetsAndSetsVersion()
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
            [DisplayFact]
            public void NotSet_ReturnsDefault()
            {
                // Arrange
                var replayData = new ReplayData();

                // Act
                var startZone = replayData.StartZone;

                // Assert
                Assert.Equal(1, startZone);
            }

            [DisplayFact(nameof(ReplayData.StartZone))]
            public void GetsAndSetsStartZone()
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
            [DisplayFact(nameof(ReplayData.StartCoins))]
            public void GetsAndSetsStartCoins()
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
            [DisplayFact(nameof(ReplayData.HasBroadsword))]
            public void GetsAndSetsHasBroadsword()
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
            [DisplayFact(nameof(ReplayData.IsHardcore))]
            public void GetsAndSetsIsHardcore()
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
            [DisplayFact(nameof(ReplayData.IsDaily))]
            public void GetsAndSetsIsDaily()
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
            [DisplayFact(nameof(ReplayData.IsDancePadMode))]
            public void GetsAndSetsIsDancePadMode()
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
            [DisplayFact(nameof(ReplayData.IsSeeded))]
            public void GetsAndSetsIsSeeded()
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
            [DisplayFact(nameof(ReplayData.Run))]
            public void GetsAndSetsRun()
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

        public class Unknown0Property
        {
            [DisplayFact(nameof(ReplayData.Unknown0))]
            public void GetsAndSetsUnknown0()
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

        public class Unknown2Property
        {
            [DisplayFact(nameof(ReplayData.Unknown2))]
            public void GetsAndSetsUnknown2()
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
            [DisplayFact(nameof(ReplayData.Duration))]
            public void GetsAndSetsDuration()
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
            [DisplayFact(nameof(ReplayData.Songs))]
            public void GetsSongs()
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
            [DisplayFact(nameof(ReplayData.SaveData))]
            public void GetsAndSetsSaveData()
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

        public class SeedProperty
        {
            [DisplayFact]
            public void NoSongs_ReturnsNull()
            {
                // Arrange
                var replayData = new ReplayData();

                // Act
                var seed = replayData.Seed;

                // Assert
                Assert.Null(seed);
            }

            [DisplayTheory]
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

            [DisplayTheory]
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
