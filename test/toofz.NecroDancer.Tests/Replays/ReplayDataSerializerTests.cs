using System.IO;
using System.Text;
using toofz.NecroDancer.Replays;
using toofz.NecroDancer.Tests.Properties;
using Xunit;

namespace toofz.NecroDancer.Tests.Replays
{
    public class ReplayDataSerializerTests
    {
        public class Constructor
        {
            [DisplayFact(nameof(ReplayDataSerializer))]
            public void ReturnsReplayDataSerializer()
            {
                // Arrange -> Act
                var serializer = new ReplayDataSerializer();

                // Assert
                Assert.IsAssignableFrom<ReplayDataSerializer>(serializer);
            }
        }

        public class DeserializeMethod
        {
            [DisplayFact(nameof(ReplayData))]
            public void ReturnsReplayData()
            {
                // Arrange
                var serializer = new ReplayDataSerializer();
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(Resources.ClassicReplayData));

                // Act
                var replayData = serializer.Deserialize(stream);

                // Assert
                Assert.IsAssignableFrom<ReplayData>(replayData);
            }
        }

        public class SerializeMethod
        {
            [DisplayFact(nameof(ReplayData))]
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
                Assert.Equal(@"0\n1\n0\n0\n0\n0\n0\n0\n0\n0\n\n", sr.ReadToEnd());
            }
        }
    }
}
