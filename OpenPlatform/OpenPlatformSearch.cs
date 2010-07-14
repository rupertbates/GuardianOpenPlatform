using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using System.Configuration;
namespace Guardian.OpenPlatform
{
    public class OpenPlatformSearch
    {
        protected IApiService _service;
        protected string _apiKey;
        protected string _apiUrl;

        #region Constructors
        public OpenPlatformSearch() : this(new ApiFacade()) { }
        public OpenPlatformSearch(IApiService service)
        {
            _service = service;
            _apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
            
            if (string.IsNullOrEmpty(_apiUrl))
                throw new ConfigurationErrorsException("The ApiUrl config setting is missing");
            
            _apiKey = ConfigurationManager.AppSettings["ApiKey"];
            if (string.IsNullOrEmpty(_apiKey))
                throw new ConfigurationErrorsException("The ApiKey config setting is missing");
        }
        public OpenPlatformSearch(string apiKey, string apiUrl) : this(new ApiFacade(), apiKey, apiUrl) { }
        public OpenPlatformSearch(IApiService service, string apiKey, string apiUrl)
        {
            _service = service;
            _apiKey = apiKey;
            _apiUrl = apiUrl;
        }
        #endregion

        public QueryTranslator GetQueryTranslator() 
        {
            return new QueryTranslator(_apiKey, _apiUrl);
        }
        #region Content search
        /// <summary>
        /// Search for Content
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public SearchResults Search(ContentSearchParameters parameters)
        {
            var query = GetQueryTranslator().Translate(parameters);
            var xml = _service.LoadContent(query);
            var results = new ObjectDeserializer().Deserialize<SearchResults>(xml);
            return results;
        }
        public void SearchASync(ContentSearchParameters parameters, SearchCallback callback)
        {
            var query = GetQueryTranslator().Translate(parameters);
            LoadXmlDelegate dlgt = new LoadXmlDelegate(_service.LoadContent);

            dlgt.BeginInvoke(query, 
                new AsyncCallback(SearchAsyncCallback), 
                new AsyncSearchCallbackParameter { Delegate = dlgt, CallbackFunction = callback });
 
        }
        internal void SearchAsyncCallback(IAsyncResult result)
        {
            var cbp = (AsyncSearchCallbackParameter) result.AsyncState;
            var results = new ObjectDeserializer().Deserialize<SearchResults>(cbp.Delegate.EndInvoke(result));
            cbp.CallbackFunction.Invoke(results);
        }
        #endregion

        #region Get content item
        /// <summary>
        /// Retrieve an item of Content by id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public Content Item(int itemId)
        {
            var query = GetQueryTranslator().Translate(itemId);
            var xml = _service.LoadContent(query);
            var results = new ObjectDeserializer().Deserialize<Content>(xml);
            return results;
        }
        public void ItemASync(int itemId, ItemCallback callback)
        {
            var query = GetQueryTranslator().Translate(itemId);
            LoadXmlDelegate dlgt = new LoadXmlDelegate(_service.LoadContent);

            dlgt.BeginInvoke(query,
                new AsyncCallback(ItemAsyncCallback),
                new AsyncItemCallbackParameter { Delegate = dlgt, CallbackFunction = callback });

        }
        internal void ItemAsyncCallback(IAsyncResult result)
        {
            var cbp = (AsyncItemCallbackParameter)result.AsyncState;
            var item = new ObjectDeserializer().Deserialize<Content>(cbp.Delegate.EndInvoke(result));
            cbp.CallbackFunction.Invoke(item);
        }
        #endregion

        #region Tag search
        /// <summary>
        /// Search for tags
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public TagResults Tags(TagSearchParameters parameters)
        {
            var query = GetQueryTranslator().Translate(parameters);
            var xml = _service.LoadContent(query);
            var results = new ObjectDeserializer().Deserialize<TagResults>(xml);
            return results;
        }
        public void TagsASync(TagSearchParameters parameters, TagsCallback callback)
        {
            var query = GetQueryTranslator().Translate(parameters);
            LoadXmlDelegate dlgt = new LoadXmlDelegate(_service.LoadContent);

            dlgt.BeginInvoke(query,
                new AsyncCallback(TagsAsyncCallback),
                new AsyncTagsCallbackParameter { Delegate = dlgt, CallbackFunction = callback });

        }
        internal void TagsAsyncCallback(IAsyncResult result)
        {
            var cbp = (AsyncTagsCallbackParameter)result.AsyncState;
            var results = new ObjectDeserializer().Deserialize<TagResults>(cbp.Delegate.EndInvoke(result));
            cbp.CallbackFunction.Invoke(results);
        }
        #endregion

    }
}
