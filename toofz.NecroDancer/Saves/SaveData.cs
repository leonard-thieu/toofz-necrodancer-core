using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using log4net;

namespace toofz.NecroDancer.Saves
{
    // Game version: 2.55
    [XmlRoot("necrodancer")]
    public sealed class SaveData
    {
        static readonly ILog Log = LogManager.GetLogger(typeof(SaveData));

        const string InvalidXmlDeclaration = "<?xml?>";

        static readonly XmlSerializer SaveDataSerializer = new XmlSerializer(typeof(SaveData));

        public static SaveData Parse(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream), $"{nameof(stream)} is null.");
            if (!stream.CanSeek)
                throw new ArgumentException($"{nameof(stream)} is not seekable.", nameof(stream));

            var startPos = stream.Position;

            var sr = new StreamReader(stream);
            var buffer = new char[InvalidXmlDeclaration.Length];
            sr.ReadBlock(buffer, (int)startPos, InvalidXmlDeclaration.Length);

            stream.Position = new string(buffer) == InvalidXmlDeclaration ?
                startPos + InvalidXmlDeclaration.Length :
                startPos;

            SaveDataSerializer.UnknownElement += OnUnknownElement;
            SaveDataSerializer.UnknownAttribute += OnUnknownAttribute;

            var saveData = (SaveData)SaveDataSerializer.Deserialize(stream);

            SaveDataSerializer.UnknownElement -= OnUnknownElement;
            SaveDataSerializer.UnknownAttribute -= OnUnknownAttribute;

            return saveData;

            void OnUnknownElement(object sender, XmlElementEventArgs e)
            {
                Log.Debug($"[{e.LineNumber}:{e.LinePosition}] Unknown element: '{e.Element.Name}'.");
            }

            void OnUnknownAttribute(object sender, XmlAttributeEventArgs e)
            {
                Log.Debug($"[{e.LineNumber}:{e.LinePosition}] Unknown attribute: '{e.ObjectBeingDeserialized}.{e.Attr.Name}'.");
            }
        }

        public static SaveData Load(string path)
        {
            using (var fs = File.OpenRead(path))
            {
                return Parse(fs);
            }
        }

        [XmlAttribute("cloudTimestamp")]
        public int CloudTimestamp { get; set; }

        [XmlElement("player")]
        public Player Player { get; set; }
        [XmlElement("game")]
        public Game Game { get; set; }
        [XmlElement("npc")]
        public Npc Npc { get; set; }
    }
}
