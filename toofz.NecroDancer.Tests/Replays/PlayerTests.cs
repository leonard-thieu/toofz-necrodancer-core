using System.Collections.Generic;
using toofz.NecroDancer.Replays;
using Xunit;

namespace toofz.NecroDancer.Tests.Replays
{
    public class PlayerTests
    {
        public class Constructor
        {
            [Fact]
            public void ReturnsInstance()
            {
                // Arrange -> Act
                var player = new Player();

                // Assert
                Assert.IsAssignableFrom<Player>(player);
            }
        }

        public class CharacterProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var player = new Player();
                var character = 5;

                // Act
                player.Character = character;
                var character2 = player.Character;

                // Assert
                Assert.Equal(character, character2);
            }
        }

        public class MovesProperty
        {
            [Fact]
            public void ReturnsMoves()
            {
                // Arrange
                var player = new Player();

                // Act
                var moves = player.Moves;

                // Assert
                Assert.IsAssignableFrom<List<Move>>(moves);
            }
        }

        public class MissedBeatsProperty
        {
            [Fact]
            public void ReturnsMissedBeats()
            {
                // Arrange
                var player = new Player();

                // Act
                var missedBeats = player.MissedBeats;

                // Assert
                Assert.IsAssignableFrom<List<int>>(missedBeats);
            }
        }
    }
}
