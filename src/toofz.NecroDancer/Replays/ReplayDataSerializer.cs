using System.IO;

namespace toofz.NecroDancer.Replays
{
    public sealed class ReplayDataSerializer
    {
        public ReplayData Deserialize(Stream stream)
        {
            var reader = new ReplayDataStreamReader(stream);

            return reader.ReadReplayData();
        }

        public void Serialize(Stream stream, ReplayData replayData)
        {
            var writer = new ReplayDataStreamWriter(stream);
            writer.Write(replayData);
        }
    }
}
