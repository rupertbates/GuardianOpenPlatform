using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Guardian.OpenPlatform
{
    public class ObjectDeserializer
    {
        public T Deserialize<T>(XmlDocument xml)
        {
            return Deserialize<T>(xml.OuterXml);
        }
        public T Deserialize<T>(string xml)
        {
            TextReader reader = new StringReader(xml);
            var xs = new XmlSerializer(typeof(T));
            var obj = (T) xs.Deserialize(reader);
            reader.Close();
            return obj;
        }
    }
}
