using System.Xml;
using Guardian.OpenPlatform.Results;
using Guardian.OpenPlatform.Results.Entities;
using Guardian.OpenPlatform.Results.SearchResponses;

namespace Guardian.OpenPlatform.Async
{
    internal delegate string LoadJsonDelegate(string query);
    public delegate void ContentSearchCallback(ContentSearchResponse response);
    public delegate void ItemCallback(Content item);
    public delegate void TagSearchCallback(TagSearchResponse response);
}
