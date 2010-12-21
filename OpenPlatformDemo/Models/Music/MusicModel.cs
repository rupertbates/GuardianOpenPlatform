using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Guardian.OpenPlatform;

namespace OpenPlatformDemo.Models.Music
{
	public class MusicModel
	{
		public DateTime Day { get; set; }
		public IEnumerable<Content> PopAndRock { get; set; }
		public IEnumerable<Content> Classical { get; set; }
		public IEnumerable<Content> Electronic { get; set; }
		public IEnumerable<Content> Urban { get; set; }
		public IEnumerable<Content> Folk { get; set; }
		public IEnumerable<Content> WorldMusic { get; set; }
		public IEnumerable<Content> All { get; set; }
	}
}
