using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Oddysey
{
    public class AudioFile
    {
        // private tipodedatoquealmacenabytes bytes;
        public String Name { get; set; }
        public String Author { get; set; }
        public String Album { get; set; }
        public String Year { get; set; }
        public String Lyrics { get; set; }
        public String Time { get; set; } // String??
        public String Score { get; set; }
        public String Metadata { get; set; }

        public void SetMainParameters(String name, String author, String time)
        {
            Name = name;
            Author = author;
            Time = time;
        }

        public String ToXmlString() // from https://stackoverflow.com/questions/1772004/how-can-i-make-the-xmlserializer-only-serialize-plain-xml
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
