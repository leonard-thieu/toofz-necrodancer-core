using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using toofz.NecroDancer.Replays;
using toofz.NecroDancer.Tests.Properties;

namespace toofz.NecroDancer.Tests.Replays
{
    class ReplayDataReaderTests
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
                    new ReplayDataReader(stream);
                });
            }

            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange
                var stream = Stream.Null;

                // Act
                var reader = new ReplayDataReader(stream);

                // Assert
                Assert.IsInstanceOfType(reader, typeof(ReplayDataReader));
            }
        }

        [TestClass]
        public class ReadMethod
        {
            [TestMethod]
            public void ReturnsReplayData()
            {
                // Arrange
                var stream = new MemoryStream(Resources.LocalCadenceWin);
                var reader = new ReplayDataReader(stream);

                // Act
                var replayData = reader.Read();

                // Assert
                Assert.IsInstanceOfType(replayData, typeof(ReplayData));
            }
        }
    }
}
