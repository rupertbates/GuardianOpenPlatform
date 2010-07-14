using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Guardian.OpenPlatform
{
    internal delegate XmlDocument LoadXmlDelegate(string query);
    public delegate void SearchCallback(SearchResults results);
    public delegate void ItemCallback(Content item);
    public delegate void TagsCallback(TagResults results);
}
