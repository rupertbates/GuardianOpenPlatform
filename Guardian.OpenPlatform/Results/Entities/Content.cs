    using System;

namespace Guardian.OpenPlatform.Results.Entities
{
    public class Content : SectionContentBase 
    { 
        public DateTime WebPublicationDate { get; set; }
        public ContentFields Fields { get; set; }
        public MediaAsset[] MediaAssets { get; set; }
        public Tag[] Tags { get; set; }
        
        #region Inner class ContentFields
        public class ContentFields
        {
            public string Headline { get; set; }
            public string TrailText { get; set; }
            public string Body { get; set; }
            public bool? HasStoryPackage { get; set; }
            public string ShortUrl { get; set; }
            public string Standfirst { get; set; }
            public bool? Commentable { get; set; }
            public string Thumbnail { get; set; }
            public string Byline { get; set; }
            public string Publication { get; set; }
            public int? StarRating { get; set; }
            public bool? LiveBloggingNow { get; set; }
        }
#endregion
    }
}