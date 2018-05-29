using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OddyseyUI
{
    [XmlRoot("OperationData")]
    public class OperationData
    {
        [XmlElement("AudioFiles")]
        public List<AudioFile> AudioFiles { get; set; }
        [XmlElement("SongToAdd")]
        public AudioFile SongToAdd { get; set; }
        [XmlElement("NameToDel")]
        public string NameToDel { get; set; }
        [XmlElement("AuthorToDel")]
        public string AuthorToDel { get; set; }
        [XmlElement("SongData")]
        public string SongData { get; set; }
        [XmlElement("SongToUpdate")]
        public AudioFile SongToUpdate { get; set; }

        public OperationData()
        {
            AudioFiles = new List<AudioFile>();
        }
    }
}
