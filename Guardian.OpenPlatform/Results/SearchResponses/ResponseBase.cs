using Guardian.OpenPlatform.Results.Entities;

namespace Guardian.OpenPlatform.Results.SearchResponses
{
    public interface IResponse
    {
        string Status { get; set; }
        UserTiers UserTier { get; set; }
        int Total { get; set; }
    }
    public interface ISearchResponse : IResponse
    {
        ContentBase[] Results { get; set; }
    }
    public abstract class ResponseBase : IResponse
    {
        public string Status { get; set; }
        public UserTiers UserTier { get; set; }
        public int Total { get; set; }
    }
}