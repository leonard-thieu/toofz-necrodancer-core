using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using toofz.NecroDancer.Replays;

namespace toofz.NecroDancer.Tests.Replays
{
    class SongTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange -> Song
                var song = new Song();

                // Assert
                Assert.IsInstanceOfType(song, typeof(Song));
            }
        }

        [TestClass]
        public class SeedProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var song = new Song();
                var seed = 234234;

                // Act
                song.Seed = seed;
                var seed2 = song.Seed;

                // Assert
                Assert.AreEqual(seed, seed2);
            }
        }

        [TestClass]
        public class Unknown0Property
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var song = new Song();
                var unknown0 = 1;

                // Act
                song.Unknown0 = unknown0;
                var unknown02 = song.Unknown0;

                // Assert
                Assert.AreEqual(unknown0, unknown02);
            }
        }

        [TestClass]
        public class Unknown1Property
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var song = new Song();
                var unknown1 = 1;

                // Act
                song.Unknown1 = unknown1;
                var unknown12 = song.Unknown1;

                // Assert
                Assert.AreEqual(unknown1, unknown12);
            }
        }

        [TestClass]
        public class BeatCountProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var song = new Song();
                var beatCount = 20;

                // Act
                song.BeatCount = beatCount;
                var beatCount2 = song.BeatCount;

                // Assert
                Assert.AreEqual(beatCount, beatCount2);
            }
        }

        [TestClass]
        public class PlayersProperty
        {
            [TestMethod]
            public void ReturnsPlayers()
            {
                // Arrange
                var song = new Song();

                // Act
                var players = song.Players;

                // Assert
                Assert.IsInstanceOfType(players, typeof(List<Player>));
            }
        }

        [TestClass]
        public class RandomMovesProperty
        {
            [TestMethod]
            public void ReturnsRandomMoves()
            {
                // Arrange
                var song = new Song();

                // Act
                var randomMoves = song.RandomMoves;

                // Assert
                Assert.IsInstanceOfType(randomMoves, typeof(List<int>));
            }
        }

        [TestClass]
        public class ItemRollsProperty
        {
            [TestMethod]
            public void ReturnsItemRolls()
            {
                // Arrange
                var song = new Song();

                // Act
                var itemRolls = song.ItemRolls;

                // Assert
                Assert.IsInstanceOfType(itemRolls, typeof(List<int>));
            }
        }
    }
}
