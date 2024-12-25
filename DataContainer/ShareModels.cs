using System.Xml.Serialization;

namespace DataContainer
{
    [XmlRoot("VersionNote")]
    public class VersionNote
    {
        [XmlElement("Version")]
        public Version Version { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }
    }

    public class Version
    {
        [XmlElement("Major")]
        public int Major { get; set; }
        [XmlElement("Minor")]
        public int Minor { get; set; }
        [XmlElement("Build")]
        public int Build { get; set; }
    }
}
