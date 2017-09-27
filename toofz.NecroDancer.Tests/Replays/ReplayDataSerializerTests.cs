using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using toofz.NecroDancer.Replays;
using toofz.NecroDancer.Tests.Properties;

namespace toofz.NecroDancer.Tests.Replays
{
    class ReplayDataSerializerTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange -> Act
                var serializer = new ReplayDataSerializer();

                // Assert
                Assert.IsInstanceOfType(serializer, typeof(ReplayDataSerializer));
            }
        }

        [TestClass]
        public class DeserializeMethod
        {
            [TestMethod]
            public void ReturnsReplayData()
            {
                // Arrange
                var serializer = new ReplayDataSerializer();
                var stream = new MemoryStream(Resources.ClassicReplayData);

                // Act
                var replayData = serializer.Deserialize(stream);

                // Assert
                Assert.IsInstanceOfType(replayData, typeof(ReplayData));
            }
        }

        [TestClass]
        public class SerializeMethod
        {
            [TestMethod]
            public void WritesReplayData()
            {
                // Arrange
                var serializer = new ReplayDataSerializer();
                var stream = new MemoryStream();
                var replayData = new ReplayData();

                // Act
                serializer.Serialize(stream, replayData);

                // Assert
                stream.Position = 0;
                var sr = new StreamReader(stream);
                Assert.AreEqual(@"0\n1\n0\n0\n0\n0\n0\n0\n0\n0\n\n", sr.ReadToEnd());
            }
        }
    }
}
