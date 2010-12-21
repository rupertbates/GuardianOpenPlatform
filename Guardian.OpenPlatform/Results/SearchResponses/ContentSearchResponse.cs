using Guardian.OpenPlatform.Results.Entities;

namespace Guardian.OpenPlatform.Results.SearchResponses
{
    public class ContentSearchResponse : ResponseBase
    {
        public int StartIndex { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int Pages { get; set; }
        public Orders OrderBy { get; set; }
        public Content[] Results { get; set; }
    }
}
