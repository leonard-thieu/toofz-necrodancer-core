using System.IO;

namespace toofz.NecroDancer.Replays
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ReplayDataSerializer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public ReplayData Deserialize(Stream stream)
        {
            var reader = new ReplayDataStreamReader(stream);

            return reader.ReadReplayData();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="replayData"></param>
        public void Serialize(Stream stream, ReplayData replayData)
        {
            var writer = new ReplayDataStreamWriter(stream);
            writer.Write(replayData);
        }
    }
}
