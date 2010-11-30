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
            public string ShortUrl { get; set; }
            public string Standfirst { get; set; }
            public string Thumbnail { get; set; }
            public string Byline { get; set; }
            public string Publication { get; set; }
            public int? StarRating { get; set; }
        }
#endregion
    }

   
    
    public class TypeSpecific
    {
        public int PictureCount { get; set; }
        public string Body { get; set; }
        public string ContentType { get; set; }
        public byte DurationMinutes{ get; set; }
        public bool DurationMinutesSpecified{ get; set; }
        public byte DurationSeconds { get; set; }
        public bool DurationSecondsSpecified { get; set; }
        public string ShowNotes { get; set; }
        public string Caption { get; set; }
    }
}