using System;
using System.IO;
using System.Text;
using toofz.NecroDancer.Replays;
using toofz.NecroDancer.Tests.Properties;
using Xunit;

namespace toofz.NecroDancer.Tests.Replays
{
    public class ReplayDataStreamReaderTests
    {
        public class Cosntructor
        {
            [Fact]
            public void StreamIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                Stream stream = null;

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    new ReplayDataStreamReader(stream);
                });
            }

            [Fact]
            public void ReturnsInstance()
            {
                // Arrange
                var stream = Stream.Null;

                // Act
                var reader = new ReplayDataStreamReader(stream);

                // Assert
                Assert.IsAssignableFrom<ReplayDataStreamReader>(reader);
            }
        }

        public class ReadReplayDataMethod
        {
            [Fact]
            public void ClassicReplayData_ReturnsReplayData()
            {
                // Arrange
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(Resources.ClassicReplayData));
                var reader = new ReplayDataStreamReader(stream);

                // Act
                var replayData = reader.ReadReplayData();

                // Assert
                var expectedStream = new MemoryStream();
                var writer = new ReplayDataStreamWriter(expectedStream);
                writer.Write(replayData);
                var expected = expectedStream.ToArray();
                Assert.Equal(expected, Encoding.UTF8.GetBytes(Resources.ClassicReplayData));
            }

            [Fact]
            public void AmplifiedReplayData_ReturnsReplayData()
            {
                // Arrange
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(Resources.AmplifiedReplayData));
                var reader = new ReplayDataStreamReader(stream);

                // Act
                var replayData = reader.ReadReplayData();

                // Assert
                var expectedStream = new MemoryStream();
                var writer = new ReplayDataStreamWriter(expectedStream);
                writer.Write(replayData);
                var expected = expectedStream.ToArray();
                Assert.Equal(expected, Encoding.UTF8.GetBytes(Resources.AmplifiedReplayData));
            }

            [Fact]
            public void RemoteReplayData_ReturnsReplayData()
            {
                // Arrange
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(Resources.RemoteReplayData));
                var reader = new ReplayDataStreamReader(stream);

                // Act
                var replayData = reader.ReadReplayData();

                // Assert
                var expectedStream = new MemoryStream();
                var writer = new ReplayDataStreamWriter(expectedStream);
                writer.Write(replayData);
                var expected = expectedStream.ToArray();
                Assert.Equal(expected, Encoding.UTF8.GetBytes(Resources.RemoteReplayData));
            }

            [Fact(Skip = "Should empty replays be parsable?")]
            public void EmptyReplayData_ReturnsReplayData()
            {
                // Arrange
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(Resources.EmptyReplayData));
                var reader = new ReplayDataStreamReader(stream);

                // Act
                var replayData = reader.ReadReplayData();

                // Assert
                var expectedStream = new MemoryStream();
                var writer = new ReplayDataStreamWriter(expectedStream);
                writer.Write(replayData);
                var expected = expectedStream.ToArray();
                Assert.Equal(expected, Encoding.UTF8.GetBytes(Resources.EmptyReplayData));
            }
        }

        public class ReadLineMethod
        {
            [Fact]
            public void ReturnsLine()
            {
                // Arrange
                var replay = @"a\nb";
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(replay));
                var reader = new ReplayDataStreamReader(stream);

                // Act
                var line = reader.ReadLine();

                // Assert
                Assert.Equal("a", line);
            }

            [Fact]
            public void NoMoreLines_ReturnsNull()
            {
                // Arrange
                var replay = @"a\nb";
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(replay));
                var reader = new ReplayDataStreamReader(stream);

                // Act
                reader.ReadLine();
                reader.ReadLine();
                var line = reader.ReadLine();

                // Assert
                Assert.Null(line);
            }
        }
    }
}
