using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using toofz.NecroDancer.Replays;
using toofz.NecroDancer.Saves;

namespace toofz.NecroDancer.Tests.Replays
{
    class ReplayDataTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange -> Act
                var replayData = new ReplayData();

                // Assert
                Assert.IsInstanceOfType(replayData, typeof(ReplayData));
            }
        }

        [TestClass]
        public class KilledByProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var killedBy = "BOMB";

                // Act
                replayData.KilledBy = killedBy;
                var killedBy2 = replayData.KilledBy;

                // Assert
                Assert.AreEqual(killedBy, killedBy2);
            }
        }

        [TestClass]
        public class IsRemoteProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var isRemote = true;

                // Act
                replayData.IsRemote = isRemote;
                var isRemote2 = replayData.IsRemote;

                // Assert
                Assert.AreEqual(isRemote, isRemote2);
            }
        }

        [TestClass]
        public class VersionProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var version = 84;

                // Act
                replayData.Version = version;
                var version2 = replayData.Version;

                // Assert
                Assert.AreEqual(version, version2);
            }
        }

        [TestClass]
        public class StartZoneProperty
        {
            [TestMethod]
            public void Default_Returns1()
            {
                // Arrange
                var replayData = new ReplayData();

                // Act
                var startZone = replayData.StartZone;

                // Assert
                Assert.AreEqual(1, startZone);
            }

            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var startZone = 2;

                // Act
                replayData.StartZone = startZone;
                var startZone2 = replayData.StartZone;

                // Assert
                Assert.AreEqual(startZone, startZone2);
            }
        }

        [TestClass]
        public class StartCoinsProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var startCoins = 10;

                // Act
                replayData.StartCoins = startCoins;
                var startCoins2 = replayData.StartCoins;

                // Assert
                Assert.AreEqual(startCoins, startCoins2);
            }
        }

        [TestClass]
        public class HasBroadswordProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var hasBroadsword = true;

                // Act
                replayData.HasBroadsword = hasBroadsword;
                var hasBroadsword2 = replayData.HasBroadsword;

                // Assert
                Assert.AreEqual(hasBroadsword, hasBroadsword2);
            }
        }

        [TestClass]
        public class IsHardcoreProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var isHardcore = true;

                // Act
                replayData.IsHardcore = isHardcore;
                var isHardcore2 = replayData.IsHardcore;

                // Assert
                Assert.AreEqual(isHardcore, isHardcore2);
            }
        }

        [TestClass]
        public class IsDailyProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var isDaily = true;

                // Act
                replayData.IsDaily = isDaily;
                var isDaily2 = replayData.IsDaily;

                // Assert
                Assert.AreEqual(isDaily, isDaily2);
            }
        }

        [TestClass]
        public class IsDancePadModeProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var isDancePadMode = true;

                // Act
                replayData.IsDancePadMode = isDancePadMode;
                var isDancePadMode2 = replayData.IsDancePadMode;

                // Assert
                Assert.AreEqual(isDancePadMode, isDancePadMode2);
            }
        }

        [TestClass]
        public class IsSeededProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var isSeeded = true;

                // Act
                replayData.IsSeeded = isSeeded;
                var isSeeded2 = replayData.IsSeeded;

                // Assert
                Assert.AreEqual(isSeeded, isSeeded2);
            }
        }

        [TestClass]
        public class RunProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var run = 1;

                // Act
                replayData.Run = run;
                var run2 = replayData.Run;

                // Assert
                Assert.AreEqual(run, run2);
            }
        }

        [TestClass]
        public class Unknown0
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var unknown0 = 1;

                // Act
                replayData.Unknown0 = unknown0;
                var unknown02 = replayData.Unknown0;

                // Assert
                Assert.AreEqual(unknown0, unknown02);
            }
        }

        [TestClass]
        public class Unknown2
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var unknown2 = 1;

                // Act
                replayData.Unknown2 = unknown2;
                var unknown22 = replayData.Unknown2;

                // Assert
                Assert.AreEqual(unknown2, unknown22);
            }
        }

        [TestClass]
        public class DurationProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var duration = TimeSpan.FromSeconds(15);

                // Act
                replayData.Duration = duration;
                var duration2 = replayData.Duration;

                // Assert
                Assert.AreEqual(duration, duration2);
            }
        }

        [TestClass]
        public class SongsProperty
        {
            [TestMethod]
            public void ReturnsSongs()
            {
                // Arrange
                var replayData = new ReplayData();

                // Act
                var songs = replayData.Songs;

                // Assert
                Assert.IsInstanceOfType(songs, typeof(ICollection<Song>));
            }
        }

        [TestClass]
        public class SaveDataProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var replayData = new ReplayData();
                var saveData = new SaveData();

                // Act
                replayData.SaveData = saveData;
                var saveData2 = replayData.SaveData;

                // Assert
                Assert.AreEqual(saveData, saveData2);
            }
        }

        [TestClass]
        public class Seed
        {
            [TestMethod]
            public void NoSongs_ReturnsNull()
            {
                // Arrange
                var replayData = new ReplayData();

                // Act
                var seed = replayData.Seed;

                // Assert
                Assert.IsNull(seed);
            }

            [DataTestMethod]
            [DataRow(1580050689, 603033)]
            [DataRow(-2147483141, 89527)]
            public void ClassicFormat_ReturnsSeed(int levelSeed, int seed)
            {
                // Arrange
                var replayData = new ReplayData();
                var song = new Song { Seed = levelSeed };
                replayData.Songs.Add(song);

                // Act
                var seed2 = replayData.Seed;

                // Assert
                Assert.AreEqual(seed, seed2);
            }

            [DataTestMethod]
            [DataRow(1368956533, 25192)]
            [DataRow(58192416, 65)]
            [DataRow(1698929060, 68295)]
            public void AmplifiedFormat_ReturnsCorrectSeed(int levelSeed, int seed)
            {
                // Arrange
                var replayData = new ReplayData { Version = 84 };
                var song = new Song { Seed = levelSeed };
                replayData.Songs.Add(song);

                // Act
                var seed2 = replayData.Seed;

                // Assert
                Assert.AreEqual(seed, seed2);
            }
        }
    }
}
