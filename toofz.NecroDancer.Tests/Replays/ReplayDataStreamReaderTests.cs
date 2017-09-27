using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using toofz.NecroDancer.Replays;
using toofz.NecroDancer.Tests.Properties;

namespace toofz.NecroDancer.Tests.Replays
{
    class ReplayDataStreamReaderTests
    {
        [TestClass]
        public class Cosntructor
        {
            [TestMethod]
            public void StreamIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                Stream stream = null;

                // Act -> Assert
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    new ReplayDataStreamReader(stream);
                });
            }

            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange
                var stream = Stream.Null;

                // Act
                var reader = new ReplayDataStreamReader(stream);

                // Assert
                Assert.IsInstanceOfType(reader, typeof(ReplayDataStreamReader));
            }
        }

        [TestClass]
        public class ReadReplayDataMethod
        {
            [TestMethod]
            public void ClassicReplayData_ReturnsReplayData()
            {
                // Arrange
                var stream = new MemoryStream(Resources.ClassicReplayData);
                var reader = new ReplayDataStreamReader(stream);

                // Act
                var replayData = reader.ReadReplayData();

                // Assert
                var expectedStream = new MemoryStream();
                var writer = new ReplayDataStreamWriter(expectedStream);
                writer.Write(replayData);
                var expected = expectedStream.ToArray();
                CollectionAssert.AreEqual(expected, Resources.ClassicReplayData);
            }

            [TestMethod]
            public void AmplifiedReplayData_ReturnsReplayData()
            {
                // Arrange
                var stream = new MemoryStream(Resources.AmplifiedReplayData);
                var reader = new ReplayDataStreamReader(stream);

                // Act
                var replayData = reader.ReadReplayData();

                // Assert
                var expectedStream = new MemoryStream();
                var writer = new ReplayDataStreamWriter(expectedStream);
                writer.Write(replayData);
                var expected = expectedStream.ToArray();
                CollectionAssert.AreEqual(expected, Resources.AmplifiedReplayData);
            }

            [TestMethod]
            public void RemoteReplayData_ReturnsReplayData()
            {
                // Arrange
                var stream = new MemoryStream(Resources.RemoteReplayData);
                var reader = new ReplayDataStreamReader(stream);

                // Act
                var replayData = reader.ReadReplayData();

                // Assert
                var expectedStream = new MemoryStream();
                var writer = new ReplayDataStreamWriter(expectedStream);
                writer.Write(replayData);
                var expected = expectedStream.ToArray();
                CollectionAssert.AreEqual(expected, Resources.RemoteReplayData);
            }

            [TestMethod]
            [Ignore]
            public void EmptyReplayData_ReturnsReplayData()
            {
                // Arrange
                var stream = new MemoryStream(Resources.EmptyReplayData);
                var reader = new ReplayDataStreamReader(stream);

                // Act
                var replayData = reader.ReadReplayData();

                // Assert
                var expectedStream = new MemoryStream();
                var writer = new ReplayDataStreamWriter(expectedStream);
                writer.Write(replayData);
                var expected = expectedStream.ToArray();
                CollectionAssert.AreEqual(expected, Resources.EmptyReplayData);
            }
        }

        [TestClass]
        public class ReadLineMethod
        {
            [TestMethod]
            public void ReturnsLine()
            {
                // Arrange
                var replay = @"a\nb";
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(replay));
                var reader = new ReplayDataStreamReader(stream);

                // Act
                var line = reader.ReadLine();

                // Assert
                Assert.AreEqual("a", line);
            }

            [TestMethod]
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
                Assert.IsNull(line);
            }
        }
    }
}
