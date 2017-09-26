using System.IO;

namespace toofz.NecroDancer.Replays
{
    public sealed class ReplayDataWriter
    {
        public ReplayDataWriter(Stream stream)
        {
            writer = new ReplayDataStreamWriter(stream);
        }

        readonly ReplayDataStreamWriter writer;

        public void Write(ReplayData replayData)
        {
            writer.Write(replayData);
        }
    }
}
