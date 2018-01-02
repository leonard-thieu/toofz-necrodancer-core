using System.IO;

namespace toofz.NecroDancer.Saves
{
    public sealed class SaveDataSerializer
    {
        public SaveData Deserialize(Stream stream)
        {
            var reader = new SaveDataReader(stream);

            return reader.Read();
        }

        public void Serialize(Stream stream, SaveData saveData)
        {
            var writer = new SaveDataWriter(stream);
            writer.Write(saveData);
        }
    }
}
