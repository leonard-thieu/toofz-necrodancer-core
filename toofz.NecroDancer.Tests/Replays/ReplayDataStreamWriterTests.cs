using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using toofz.NecroDancer.Replays;
using toofz.NecroDancer.Tests.Properties;

namespace toofz.NecroDancer.Tests.Replays
{
    class ReplayDataStreamWriterTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void StreamIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                Stream stream = null;

                // Act -> Assert
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    new ReplayDataStreamWriter(stream);
                });
            }

            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange
                var stream = Stream.Null;

                // Act
                var writer = new ReplayDataStreamWriter(stream);

                // Assert
                Assert.IsInstanceOfType(writer, typeof(ReplayDataStreamWriter));
            }
        }

        [TestClass]
        public class WriteMethod_ReplayData
        {
            [TestMethod]
            public void ReplayDataIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var stream = Stream.Null;
                var writer = new ReplayDataStreamWriter(stream);
                ReplayData replayData = null;

                // Act -> Assert
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    writer.Write(replayData);
                });
            }

            [TestMethod]
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
                CollectionAssert.AreEqual(Encoding.UTF8.GetBytes(Resources.ClassicReplayData), actual);
            }

            [TestMethod]
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
                CollectionAssert.AreEqual(Encoding.UTF8.GetBytes(Resources.AmplifiedReplayData), actual);
            }

            [TestMethod]
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
                CollectionAssert.AreEqual(Encoding.UTF8.GetBytes(Resources.RemoteReplayData), actual);
            }
        }

        [TestClass]
        public class WriteMethod_Boolean
        {
            [TestMethod]
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
                Assert.AreEqual("0", sr.ReadToEnd());
            }

            [TestMethod]
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
                Assert.AreEqual("1", sr.ReadToEnd());
            }
        }
    }
}
