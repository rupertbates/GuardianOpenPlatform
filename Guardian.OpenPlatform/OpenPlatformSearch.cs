using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using System.Configuration;
using Guardian.Configuration;
using Guardian.OpenPlatform.Async;
using Guardian.OpenPlatform.Results;
using Guardian.OpenPlatform.Results.Entities;
using Guardian.OpenPlatform.Results.SearchResponses;

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
            _apiUrl = ConfigurationHelper.GetConfigValue("ApiUrl");
            _apiKey = ConfigurationHelper.GetConfigValueOrDefault("ApiKey", "");
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
        public ContentSearchResponse ContentSearch(ContentSearchParameters parameters)
        {
            var query = GetQueryTranslator().Translate(parameters);
            var xml = _service.LoadContent(query);
            var results = new ObjectDeserializer().Deserialize<ContentSearchResponse>(xml);
            return results;
        }
        public void ContentSearchASync(ContentSearchParameters parameters, ContentSearchCallback callback)
        {
            var query = GetQueryTranslator().Translate(parameters);
            var dlgt = new LoadJsonDelegate(_service.LoadContent);

            dlgt.BeginInvoke(query, 
                ContentSearchAsyncCallback, 
                new AsyncSearchCallbackParameter { Delegate = dlgt, CallbackFunction = callback });
 
        }
        internal void ContentSearchAsyncCallback(IAsyncResult result)
        {
            var cbp = (AsyncSearchCallbackParameter) result.AsyncState;
            var results = new ObjectDeserializer().Deserialize<ContentSearchResponse>(cbp.Delegate.EndInvoke(result));
            cbp.CallbackFunction.Invoke(results);
        }
        #endregion

        #region Get content item
        /// <summary>
        /// Retrieve an item of Content by id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public Content Item(string itemId)
        {
            var query = GetQueryTranslator().Translate(itemId);
            var xml = _service.LoadContent(query);
            var results = new ObjectDeserializer().Deserialize<ItemResponse>(xml);
            return results.Content;
        }
        public void ItemASync(string itemId, ItemCallback callback)
        {
            var query = GetQueryTranslator().Translate(itemId);
            var dlgt = new LoadJsonDelegate(_service.LoadContent);

            dlgt.BeginInvoke(query,
                ItemAsyncCallback,
                new AsyncItemCallbackParameter { Delegate = dlgt, CallbackFunction = callback });

        }
        internal void ItemAsyncCallback(IAsyncResult result)
        {
            var cbp = (AsyncItemCallbackParameter)result.AsyncState;
            var item = new ObjectDeserializer().Deserialize<ItemResponse>(cbp.Delegate.EndInvoke(result));
            cbp.CallbackFunction.Invoke(item.Content);
        }
        #endregion

        #region Tag search
        /// <summary>
        /// Search for tags
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public TagSearchResponse Tags(TagSearchParameters parameters)
        {
            var query = GetQueryTranslator().Translate(parameters);
            var xml = _service.LoadContent(query);
            var results = new ObjectDeserializer().Deserialize<TagSearchResponse>(xml);
            return results;
        }
        public void TagsASync(TagSearchParameters parameters, TagSearchCallback callback)
        {
            var query = GetQueryTranslator().Translate(parameters);
            var dlgt = new LoadJsonDelegate(_service.LoadContent);

            dlgt.BeginInvoke(query,
                TagsAsyncCallback,
                new AsyncTagsCallbackParameter { Delegate = dlgt, CallbackFunction = callback });

        }
        internal void TagsAsyncCallback(IAsyncResult result)
        {
            var cbp = (AsyncTagsCallbackParameter)result.AsyncState;
            var results = new ObjectDeserializer().Deserialize<TagSearchResponse>(cbp.Delegate.EndInvoke(result));
            cbp.CallbackFunction.Invoke(results);
        }
        #endregion

    }
}
