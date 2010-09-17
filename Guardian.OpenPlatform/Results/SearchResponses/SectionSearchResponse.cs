using Guardian.OpenPlatform.Results.Entities;

namespace Guardian.OpenPlatform.Results.SearchResponses
{
    public class SectionSearchResponse : ResponseBase
    {
        public Section[] Results { get; set; }
    }
}
