using System;
using System.IO;
using System.Text;
using toofz.NecroDancer.Replays;
using toofz.NecroDancer.Tests.Properties;
using Xunit;

namespace toofz.NecroDancer.Tests.Replays
{
    public class ReplayDataStreamWriterTests
    {
        public class Constructor
        {
            [DisplayFact(nameof(ArgumentNullException))]
            public void StreamIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                Stream stream = null;

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    new ReplayDataStreamWriter(stream);
                });
            }

            [DisplayFact(nameof(ReplayDataStreamWriter))]
            public void ReturnsReplayDataStreamWriter()
            {
                // Arrange
                var stream = Stream.Null;

                // Act
                var writer = new ReplayDataStreamWriter(stream);

                // Assert
                Assert.IsAssignableFrom<ReplayDataStreamWriter>(writer);
            }
        }

        public class WriteMethod_ReplayData
        {
            [DisplayFact(nameof(ReplayData), nameof(ArgumentNullException))]
            public void ReplayDataIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var stream = Stream.Null;
                var writer = new ReplayDataStreamWriter(stream);
                ReplayData replayData = null;

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    writer.Write(replayData);
                });
            }

            [DisplayFact(nameof(ReplayData))]
            public void ClassicReplayData_WritesReplayData()
            {
                // Arrange
                var replayDataStream = new MemoryStream(Encoding.UTF8.GetBytes(Resources.ClassicReplayData));
                var reader = new ReplayDataStreamReader(replayDataStream);
                var replayData = reader.ReadReplayData();
                var stream = new MemoryStream();
                var writer = new ReplayDataStreamWriter(stream);

                // Act
                writer.Write(replayData);

                // Assert
                var actual = stream.ToArray();
                Assert.Equal(Encoding.UTF8.GetBytes(Resources.ClassicReplayData), actual);
            }

            [DisplayFact(nameof(ReplayData))]
            public void AmplifiedReplayData_WritesReplayData()
            {
                // Arrange
                var replayDataStream = new MemoryStream(Encoding.UTF8.GetBytes(Resources.AmplifiedReplayData));
                var reader = new ReplayDataStreamReader(replayDataStream);
                var replayData = reader.ReadReplayData();
                var stream = new MemoryStream();
                var writer = new ReplayDataStreamWriter(stream);

                // Act
                writer.Write(replayData);

                // Assert
                var actual = stream.ToArray();
                Assert.Equal(Encoding.UTF8.GetBytes(Resources.AmplifiedReplayData), actual);
            }

            [DisplayFact(nameof(ReplayData))]
            public void RemoteReplayData_WritesReplayData()
            {
                // Arrange
                var replayDataStream = new MemoryStream(Encoding.UTF8.GetBytes(Resources.RemoteReplayData));
                var reader = new ReplayDataStreamReader(replayDataStream);
                var replayData = reader.ReadReplayData();
                var stream = new MemoryStream();
                var writer = new ReplayDataStreamWriter(stream);

                // Act
                writer.Write(replayData);

                // Assert
                var actual = stream.ToArray();
                Assert.Equal(Encoding.UTF8.GetBytes(Resources.RemoteReplayData), actual);
            }
        }

        public class WriteMethod_Boolean
        {
            [DisplayFact]
            public void ValueIsFalse_Writes0()
            {
                // Arrange
                var stream = new MemoryStream();
                var writer = new ReplayDataStreamWriter(stream);

                // Act
                writer.Write(false);
                writer.Flush();

                // Assert
                stream.Position = 0;
                var sr = new StreamReader(stream);
                Assert.Equal("0", sr.ReadToEnd());
            }

            [DisplayFact]
            public void ValueIsTrue_Writes1()
            {
                // Arrange
                var stream = new MemoryStream();
                var writer = new ReplayDataStreamWriter(stream);

                // Act
                writer.Write(true);
                writer.Flush();

                // Assert
                stream.Position = 0;
                var sr = new StreamReader(stream);
                Assert.Equal("1", sr.ReadToEnd());
            }
        }
    }
}
