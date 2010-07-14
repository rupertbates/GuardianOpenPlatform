using System;
using System.Xml.Serialization;

namespace Guardian.OpenPlatform
{
    [Serializable()]
    [XmlType(TypeName = "tag", AnonymousType = true)]
    public class Tag //: IEquatable<Tag>
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlAttribute("filter")]
        public string Filter { get; set; }
        [XmlAttribute("api-url")]
        public string ApiUrl { get; set; }
        [XmlAttribute("web-url")]
        public string WebUrl { get; set; }
        public override bool Equals(object obj)
        {
            
            return Filter == ((Tag) obj).Filter;
        }
		public override int GetHashCode()
		{
			return Filter.GetHashCode();
		}
		//#region IEquatable<Tag> Members

		//public bool Equals(Tag other)
		//{
		//    return Filter == other.Filter;
		//}

		//#endregion
    }
	////The final implementation
	//public class Tag : IEquatable<Tag>
	//{
	//    public string Name { get; set; }
	//    public string Type { get; set; }
	//    public string Filter { get; set; }
	//    public string ApiUrl { get; set; }
	//    public string WebUrl { get; set; }
	//    public override bool Equals(object obj)
	//    {
	//        return Filter == ((Tag)obj).Filter;
	//    }
	//    public override int GetHashCode()
	//    {
	//        return Filter.GetHashCode();
	//    }
	//    #region IEquatable<Tag> Members

	//    public bool Equals(Tag other)
	//    {
	//        return Filter == other.Filter;
	//    }
	//    #endregion
	//}
}