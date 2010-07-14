using System;
using System.Xml.Serialization;

namespace Guardian.OpenPlatform
{
    [Serializable()]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "content", Namespace = "", IsNullable = false)]
    public class Content : IEquatable<Content>
    {
        [XmlElement("publication")]
        public string Publication { get; set; }
        [XmlElement("headline")]
        public string Headline { get; set; }
        [XmlElement("standfirst")]
        public string Standfirst { get; set; }
        [XmlElement("byline")]
        public string Byline { get; set; }
        [XmlElement("section-name")]
        public string SectionName { get; set; }
        [XmlElement("trail-text")]
        public string TrailText { get; set; }
        [XmlElement("link-text")]
        public string LinkText { get; set; }
        [XmlElement("trail-image")]
        public string TrailImage { get; set; }
        [XmlElement("publication-date")]
        public DateTime PublicationDate { get; set; }
        [XmlArray("tagged-with"), XmlArrayItem("tag", IsNullable = false)]
        public Tag[] TaggedWith { get; set; }
        [XmlElement("type-specific")]
        public TypeSpecific TypeSpecific { get; set; }
        [XmlAttribute("id")]
        public uint Id { get; set; }
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlAttribute("web-url")]
        public string WebUrl { get; set; }
        [XmlAttribute("api-url")]
        public string ApiUrl { get; set; }
        public override bool Equals(object obj)
        {
            return Id == ((Content)obj).Id;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #region IEquatable<Content> Members

        public bool Equals(Content other)
        {
            return Id == other.Id;
        }

        #endregion
    }
    [Serializable()]
    [XmlType(TypeName = "type-specific", AnonymousType = true)]
    public class TypeSpecific
    {
        [XmlElement("picture-count")]
        public int PictureCount { get; set; }
        
        [XmlElement("body")]
        public string Body { get; set; }
        
        [XmlAttribute("class")]
        public string ContentType { get; set; }
        
        [XmlElement("duration-minutes")]
        public byte DurationMinutes{ get; set; }
        
        [XmlIgnore()]
        public bool DurationMinutesSpecified{ get; set; }
        
        [XmlElement("duration-seconds")]
        public byte DurationSeconds { get; set; }
        
        [XmlIgnore()]
        public bool DurationSecondsSpecified { get; set; }

        [XmlElement("show-notes")]
        public string ShowNotes { get; set; }

        [XmlElement("caption")]
        public string Caption { get; set; }

    }
}