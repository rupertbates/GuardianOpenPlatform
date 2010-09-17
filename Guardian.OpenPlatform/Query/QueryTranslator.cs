using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Guardian.Configuration;

namespace Guardian.OpenPlatform
{
    public class QueryTranslator
    {
        protected string _apiUrl;
        protected string _apiKey;
        public QueryTranslator()
        {
            _apiUrl = ConfigurationHelper.GetConfigValue("ApiUrl");
            _apiKey = ConfigurationHelper.GetConfigValue("ApiKey");

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
            parameters.Tags.ForEach(f=> qsb.AddParameter("tag", f));
            qsb.AddParameter("section", parameters.Section);
            qsb.AddParameter("from-date", parameters.From);
            qsb.AddParameter("to-date", parameters.To);
            //qsb.AddParameter("content-type", parameters.ContentType);
            qsb.AddParameter("page-size", parameters.PageSize.ToString());
            qsb.AddParameter("page", parameters.PageIndex.ToString());
            return AddBaseUriAndApiKey("search", qsb);
        }
        public string Translate(TagSearchParameters parameters)
        {
            var qsb = new QueryStringBuilder();
            qsb.AddParameter("q", parameters.Query);
            qsb.AddParameter("page-size", parameters.PageSize.ToString());
            qsb.AddParameter("page", parameters.PageIndex.ToString());
            return AddBaseUriAndApiKey("tags", qsb);
        }
        public string Translate(string itemId)
        {
            return AddBaseUriAndApiKey(itemId, new QueryStringBuilder());
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
            qsb.AddParameter("format", "json");
            qsb.AddParameter("show-fields", "all");
            qsb.AddParameter("order-by", "relevance");

            var query = _apiUrl + methodUri + qsb.GetQueryString();
            return query;
        }
    }
}
