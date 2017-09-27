using System.IO;

namespace toofz.NecroDancer.Data
{
    public sealed class NecroDancerDataSerializer
    {
        public NecroDancerData Deserialize(Stream stream)
        {
            var reader = new NecroDancerDataReader(stream);

            return reader.Read();
        }

        public void Serialize(Stream stream, NecroDancerData necroDancerData)
        {
            var writer = new NecroDancerDataWriter(stream);
            writer.Write(necroDancerData);
        }
    }
}
