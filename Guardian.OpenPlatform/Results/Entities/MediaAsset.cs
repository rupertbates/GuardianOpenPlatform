using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guardian.OpenPlatform.Results.Entities
{
    public class MediaAsset
    {
        public string Type { get; set; }
        public string Rel { get; set; }
        public int Index { get; set; }
        public string File { get; set; }
        public MediaFields Fields { get; set; }
        
        public class MediaFields
        {
            //picture fields
            public string Source { get; set; }
            public string Photographer { get; set; }
            public int Height { get; set; }
            public string Credit { get; set; }
            public string Thumbnail { get; set; }
            public string AltText { get; set; }
            public string Caption { get; set; }
            public int Width { get; set; }
            //video fields
            public bool Embeddable { get; set; }
            public int DurationSeconds { get; set; }
            public int DurationMinutes { get; set; }
            public string StillImageUrl { get; set; }
            public bool BlockAds { get; set; }
        }
    }  
}
