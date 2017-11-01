using toofz.NecroDancer.Replays;
using Xunit;

namespace toofz.NecroDancer.Tests.Replays
{
    public class MoveTests
    {
        public class Constructor
        {
            [Fact]
            public void ReturnsInstance()
            {
                // Arrange -> Act
                var move = new Move();

                // Assert
                Assert.IsAssignableFrom<Move>(move);
            }
        }

        public class BeatProperty
        {
            [Fact]
            public void GetSetBehavior()
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
            [Fact]
            public void GetSetBehavior()
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
