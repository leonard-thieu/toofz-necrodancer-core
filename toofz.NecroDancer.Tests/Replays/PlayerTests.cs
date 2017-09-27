using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using toofz.NecroDancer.Replays;

namespace toofz.NecroDancer.Tests.Replays
{
    class PlayerTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange -> Act
                var player = new Player();

                // Assert
                Assert.IsInstanceOfType(player, typeof(Player));
            }
        }

        [TestClass]
        public class CharacterProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var player = new Player();
                var character = 5;

                // Act
                player.Character = character;
                var character2 = player.Character;

                // Assert
                Assert.AreEqual(character, character2);
            }
        }

        [TestClass]
        public class MovesProperty
        {
            [TestMethod]
            public void ReturnsMoves()
            {
                // Arrange
                var player = new Player();

                // Act
                var moves = player.Moves;

                // Assert
                Assert.IsInstanceOfType(moves, typeof(List<Move>));
            }
        }

        [TestClass]
        public class MissedBeatsProperty
        {
            [TestMethod]
            public void ReturnsMissedBeats()
            {
                // Arrange
                var player = new Player();

                // Act
                var missedBeats = player.MissedBeats;

                // Assert
                Assert.IsInstanceOfType(missedBeats, typeof(List<int>));
            }
        }
    }
}
