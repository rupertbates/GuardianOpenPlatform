using System.Xml.Serialization;

namespace Guardian.OpenPlatform
{
    [XmlType(AnonymousType = true)]
    [XmlRoot("search", Namespace = "", IsNullable = false)]
    public partial class SearchResults
    {
        [XmlArray("results"), XmlArrayItem("content", IsNullable = false)]
        public Content[] Results { get; set; }

        [XmlArray("filters"), XmlArrayItem("tag", IsNullable = false)]
        public Tag[] Filters { get; set; }

        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlAttribute("start-index")]
        public byte StartIndex { get; set; }
    }
}