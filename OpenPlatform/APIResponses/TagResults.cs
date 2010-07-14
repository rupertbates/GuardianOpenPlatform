using System.Xml.Serialization;

namespace Guardian.OpenPlatform
{
    [XmlType(AnonymousType = true)]
    [XmlRoot("tags", Namespace = "", IsNullable = false)]
    public partial class TagResults
    {

        [XmlElement("tag")]
        public Tag[] Tags { get; set; }

        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlAttribute("start-index")]
        public byte StartIndex { get; set; }
    }
}