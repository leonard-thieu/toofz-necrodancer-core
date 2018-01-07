using System.IO;

namespace toofz.NecroDancer.Data
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class NecroDancerDataSerializer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public NecroDancerData Deserialize(Stream stream)
        {
            var reader = new NecroDancerDataReader(stream);

            return reader.Read();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="necroDancerData"></param>
        public void Serialize(Stream stream, NecroDancerData necroDancerData)
        {
            var writer = new NecroDancerDataWriter(stream);
            writer.Write(necroDancerData);
        }
    }
}
