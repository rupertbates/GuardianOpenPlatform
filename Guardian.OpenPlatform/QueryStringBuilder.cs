using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guardian.OpenPlatform
{
    public class QueryStringBuilder
    {
        private Dictionary<string, List<string>> parameters = new Dictionary<string, List<string>>();
        public void AddParameter(string name, DateTime? value)
        {
            //don't add in null or empty parameters
            if (!value.HasValue | string.IsNullOrEmpty(name))
                return;

            AddParameter(name, FormatDate(value));
        }
        public string FormatDate(DateTime? date)
        {
            if (!date.HasValue)
                return "";

            return date.Value.ToString("yyyy-MM-dd");
        }
        public void AddParameter(string name, string value)
        {
            //don't add in null or empty parameters
            if(string.IsNullOrEmpty(value) | string.IsNullOrEmpty(name))
                return;
            name = Uri.EscapeUriString(name.ToLower());
            value = Uri.EscapeUriString(value);
            List<string> existingValues;
            if (parameters.TryGetValue(name, out existingValues))
                existingValues.Add(value);
            else
                parameters.Add(name, new List<string> { value });
        }
        //public void AddParameter(string name, List<string> value)
        //{
        //    //don't add in null or empty parameters
        //    if (value == null || value.Count < 1 || string.IsNullOrEmpty(name))
        //        return;
        //    name = Uri.EscapeUriString(name.ToLower());

        //    value = Uri.EscapeUriString(value);
        //    List<string> existingValues;
        //    if (parameters.TryGetValue(name, out existingValues))
        //        existingValues.Add(value);
        //    else
        //        parameters.Add(name, new List<string> { value });
        //}
        public string GetQueryString()
        {
            if(parameters.Count == 0)
                return "";

            var qs = "?";
            foreach(var param in parameters )
            {
                qs += param.Key + "=";
                foreach (var val in param.Value)
                {
                    qs += val + ",";
                }
                qs = qs.TrimEnd(',') +  "&";
            }
            return qs.TrimEnd('&');
        }
    }
}
