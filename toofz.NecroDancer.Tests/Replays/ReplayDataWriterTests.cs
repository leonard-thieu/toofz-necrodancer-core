using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using toofz.NecroDancer.Replays;

namespace toofz.NecroDancer.Tests.Replays
{
    class ReplayDataWriterTests
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
                    new ReplayDataWriter(stream);
                });
            }

            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange
                var stream = Stream.Null;

                // Act
                var writer = new ReplayDataWriter(stream);

                // Assert
                Assert.IsInstanceOfType(writer, typeof(ReplayDataWriter));
            }
        }

        [TestClass]
        public class WriteMethod
        {
            [TestMethod]
            public void WritesReplay()
            {
                // Arrange
                var stream = new MemoryStream();
                var writer = new ReplayDataWriter(stream);
                var replayData = new ReplayData();

                // Act
                writer.Write(replayData);

                // Assert
                stream.Position = 0;
                var sr = new StreamReader(stream);
                Assert.AreEqual(@"0\n1\n0\n0\n0\n0\n0\n0\n0\n0\n\n", sr.ReadToEnd());
            }
        }
    }
}
