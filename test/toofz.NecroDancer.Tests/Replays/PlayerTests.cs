using System.Collections.Generic;
using toofz.NecroDancer.Replays;
using Xunit;

namespace toofz.NecroDancer.Tests.Replays
{
    public class PlayerTests
    {
        public class Constructor
        {
            [DisplayFact(nameof(Player))]
            public void ReturnsPlayer()
            {
                // Arrange -> Act
                var player = new Player();

                // Assert
                Assert.IsAssignableFrom<Player>(player);
            }
        }

        public class CharacterProperty
        {
            [DisplayFact(nameof(Player.Character))]
            public void GetsAndSetsCharacter()
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
            [DisplayFact(nameof(Player.Moves))]
            public void GetsMoves()
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
            [DisplayFact(nameof(Player.MissedBeats))]
            public void GetsMissedBeats()
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
