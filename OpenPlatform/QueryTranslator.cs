using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Guardian.OpenPlatform
{
    public class QueryTranslator
    {
        protected string _apiUrl;
        protected string _apiKey;
        public QueryTranslator()
        {
            _apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
            
            if (string.IsNullOrEmpty(_apiUrl))
                throw new ConfigurationErrorsException("The ApiUrl config setting is missing");
            
            _apiKey = ConfigurationManager.AppSettings["ApiKey"];
            if (string.IsNullOrEmpty(_apiKey))
                throw new ConfigurationErrorsException("The ApiKey config setting is missing");

        }
        public QueryTranslator(string apiKey, string apiUrl)
        {
            _apiKey = apiKey;
            _apiUrl = apiUrl;
        }
        public string Translate(ContentSearchParameters parameters)
        {
            var qsb = new QueryStringBuilder();
            qsb.AddParameter("q", parameters.Query);
            parameters.Filters.ForEach(f=> qsb.AddParameter("filter", "/" + f.TrimStart('/')));
            qsb.AddParameter("from-date", parameters.After);
            qsb.AddParameter("to-date", parameters.Before);
            qsb.AddParameter("content-type", parameters.ContentType);
            qsb.AddParameter("page-size", parameters.Count.ToString());
            qsb.AddParameter("page", parameters.StartIndex.ToString());
            return AddBaseUriAndApiKey("search", qsb);
        }
        public string Translate(TagSearchParameters parameters)
        {
            var qsb = new QueryStringBuilder();
            qsb.AddParameter("q", parameters.Query);
            qsb.AddParameter("page-size", parameters.Count.ToString());
            qsb.AddParameter("page", parameters.StartIndex.ToString());
            return AddBaseUriAndApiKey("tags", qsb);
        }
        public string Translate(int itemId)
        {
            return AddBaseUriAndApiKey(itemId.ToString(), new QueryStringBuilder());
        }
        public string FormatDate(DateTime? date)
        {
            if (!date.HasValue)
                return "";

            return date.Value.ToString("yyyyMMdd");
        }
        protected string AddBaseUriAndApiKey(string methodUri, QueryStringBuilder qsb)
        {
            qsb = qsb ?? new QueryStringBuilder();
            qsb.AddParameter("api-key", _apiKey);

            var query = _apiUrl + methodUri + qsb.GetQueryString();
            return query;
        }
    }
}
