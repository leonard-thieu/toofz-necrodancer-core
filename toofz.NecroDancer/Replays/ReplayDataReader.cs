using System.IO;

namespace toofz.NecroDancer.Replays
{
    public sealed class ReplayDataReader
    {
        /// <summary>
        /// Initializes an instance of the <see cref="ReplayDataReader"/> class for the specified stream.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="stream"/> is null.
        /// </exception>
        public ReplayDataReader(Stream stream)
        {
            reader = new ReplayDataStreamReader(stream);
        }

        readonly ReplayDataStreamReader reader;

        public ReplayData Read()
        {
            return reader.ReadReplayData();
        }
    }
}
