using System.IO;

namespace toofz.NecroDancer.Saves
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SaveDataSerializer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public SaveData Deserialize(Stream stream)
        {
            var reader = new SaveDataReader(stream);

            return reader.Read();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="saveData"></param>
        public void Serialize(Stream stream, SaveData saveData)
        {
            var writer = new SaveDataWriter(stream);
            writer.Write(saveData);
        }
    }
}
