using Guardian.OpenPlatform.Results.Entities;

namespace Guardian.OpenPlatform.Results.SearchResponses
{
    public class TagSearchResponse : ResponseBase
    {
        public Tag[] Results { get; set; }
    }
}
