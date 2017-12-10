using toofz.NecroDancer.Replays;
using Xunit;

namespace toofz.NecroDancer.Tests.Replays
{
    public class MoveTests
    {
        public class Constructor
        {
            [DisplayFact(nameof(Move))]
            public void ReturnsMove()
            {
                // Arrange -> Act
                var move = new Move();

                // Assert
                Assert.IsAssignableFrom<Move>(move);
            }
        }

        public class BeatProperty
        {
            [DisplayFact(nameof(Move.Beat))]
            public void GetsAndSetsBeat()
            {
                // Arrange
                var move = new Move();
                var beat = 20;

                // Act
                move.Beat = beat;
                var beat2 = move.Beat;

                // Assert
                Assert.Equal(beat, beat2);
            }
        }

        public class IdProperty
        {
            [DisplayFact(nameof(Move.Id))]
            public void GetsAndSetsId()
            {
                // Arrange
                var move = new Move();
                var id = 1;

                // Act
                move.Id = id;
                var id2 = move.Id;

                // Assert
                Assert.Equal(id, id2);
            }
        }
    }
}
