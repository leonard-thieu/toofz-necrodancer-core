using System.Collections.Generic;
using toofz.NecroDancer.Replays;
using Xunit;

namespace toofz.NecroDancer.Tests.Replays
{
    public class SongTests
    {
        public class Constructor
        {
            [DisplayFact(nameof(Song))]
            public void ReturnsSong()
            {
                // Arrange -> Song
                var song = new Song();

                // Assert
                Assert.IsAssignableFrom<Song>(song);
            }
        }

        public class SeedProperty
        {
            [DisplayFact(nameof(Song.Seed))]
            public void GetsAndSetsSeed()
            {
                // Arrange
                var song = new Song();
                var seed = 234234;

                // Act
                song.Seed = seed;
                var seed2 = song.Seed;

                // Assert
                Assert.Equal(seed, seed2);
            }
        }

        public class Unknown0Property
        {
            [DisplayFact(nameof(Song.Unknown0))]
            public void GetsAndSetsUnknown0()
            {
                // Arrange
                var song = new Song();
                var unknown0 = 1;

                // Act
                song.Unknown0 = unknown0;
                var unknown02 = song.Unknown0;

                // Assert
                Assert.Equal(unknown0, unknown02);
            }
        }

        public class Unknown1Property
        {
            [DisplayFact(nameof(Song.Unknown1))]
            public void GetsAndSetsUnknown1()
            {
                // Arrange
                var song = new Song();
                var unknown1 = 1;

                // Act
                song.Unknown1 = unknown1;
                var unknown12 = song.Unknown1;

                // Assert
                Assert.Equal(unknown1, unknown12);
            }
        }

        public class BeatCountProperty
        {
            [DisplayFact(nameof(Song.BeatCount))]
            public void GetsAndSetsBeatCount()
            {
                // Arrange
                var song = new Song();
                var beatCount = 20;

                // Act
                song.BeatCount = beatCount;
                var beatCount2 = song.BeatCount;

                // Assert
                Assert.Equal(beatCount, beatCount2);
            }
        }

        public class PlayersProperty
        {
            [DisplayFact(nameof(Song.Players))]
            public void GetsPlayers()
            {
                // Arrange
                var song = new Song();

                // Act
                var players = song.Players;

                // Assert
                Assert.IsAssignableFrom<List<Player>>(players);
            }
        }

        public class RandomMovesProperty
        {
            [DisplayFact(nameof(Song.RandomMoves))]
            public void GetsRandomMoves()
            {
                // Arrange
                var song = new Song();

                // Act
                var randomMoves = song.RandomMoves;

                // Assert
                Assert.IsAssignableFrom<List<int>>(randomMoves);
            }
        }

        public class ItemRollsProperty
        {
            [DisplayFact(nameof(Song.ItemRolls))]
            public void GetsItemRolls()
            {
                // Arrange
                var song = new Song();

                // Act
                var itemRolls = song.ItemRolls;

                // Assert
                Assert.IsAssignableFrom<List<int>>(itemRolls);
            }
        }
    }
}
