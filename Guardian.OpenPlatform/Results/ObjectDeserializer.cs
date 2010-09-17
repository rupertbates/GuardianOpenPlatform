using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using Guardian.OpenPlatform.Results.Entities;
using Guardian.OpenPlatform.Results.SearchResponses;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Guardian.OpenPlatform.Results;

namespace Guardian.OpenPlatform
{
    public class ObjectDeserializer
    {
        public T Deserialize<T>(string json) where T : ResponseBase
        {
            var wrapper = JsonConvert.DeserializeObject<ResponseWrapper<T>>(json);
            return (T) wrapper.Response;
        }
    }
}
