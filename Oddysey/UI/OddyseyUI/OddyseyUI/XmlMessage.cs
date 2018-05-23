using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace OddyseyUI
{
    public class XmlMessage
    {
        public String OpCode { get; set; }
        public OperationData OpData { get; set; }

        public XmlMessage()
        {
            OpData = new OperationData();
        }

        public String GetAddSongXML(AudioFile audio) // from https://stackoverflow.com/questions/1772004/how-can-i-make-the-xmlserializer-only-serialize-plain-xml
        {
            OpCode = "001";
            OpData.Audio = audio;
            return GetXMLString();
        }

        public String GetDeleteSongXML(String nameToDel, String authorToDel)
        {
            OpCode = "002";
            OpData.NameToDel = nameToDel;
            OpData.AuthorToDel = authorToDel;
            return GetXMLString();
        }

        public String GetXMLString()
        {
            var emptyNs = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(GetType());
            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true
            };
            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, this, emptyNs);
                return stream.ToString();
            }
        }
    }
}
