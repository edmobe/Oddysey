using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace OddyseyUI
{
    [XmlRoot("XmlMessage")]
    public class XmlMessage
    {
        [XmlElement("OperationData")]
        public OperationData OperationData { get; set; }

        public XmlMessage()
        {
            OperationData = new OperationData();
        }

        public String GetAddSongXML(AudioFile audio) // from https://stackoverflow.com/questions/1772004/how-can-i-make-the-xmlserializer-only-serialize-plain-xml
        {
            OperationData.SongToAdd = audio;
            return GetXMLString();
        }
        public String GetAddUserXML(User user)
        {
            OperationData.UserToAdd = user;
            return GetXMLString();
        }
        public String GetCheckUserXML(User user)
        {
            OperationData.UserToLog = user;
            return GetXMLString();
        }

        public String GetDeleteSongXML(String nameToDel, String authorToDel)
        {
            OperationData.NameToDel = nameToDel;
            OperationData.AuthorToDel = authorToDel;
            return GetXMLString();
        }

        public String GetXMLString()
        {
            var emptyNs = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(GetType());
            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true,
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
