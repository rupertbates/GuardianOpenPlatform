using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Guardian.OpenPlatform;
using OpenPlatformDemo.Models.Music;

namespace OpenPlatformDemo.Services
{
	public class MusicService
	{
		//These are the tags which match with music types
		public static readonly Tag PopAndRock = new Tag { Filter = "/music/popandrock" };
		public static readonly Tag Classical = new Tag { Filter = "/music/classicalmusicandopera" };
		public static readonly Tag Electronic = new Tag { Filter = "/music/electronicmusic" };
		public static readonly Tag Urban = new Tag { Filter = "/music/urban" };
		public static readonly Tag Folk = new Tag { Filter = "/music/folk" };
		public static readonly Tag WorldMusic = new Tag { Filter = "/music/worldmusic" };
		public static readonly Tag[] MusicTypes = new[]
		{
			PopAndRock, Classical, Electronic, Urban, Folk, WorldMusic
        };
		public static SearchResults GetMusicContentForLastNDays(double numberOfDays)
		{
			var op = new OpenPlatformSearch();
			var date = DateTime.Today.AddDays(-numberOfDays);
			var results = op.Search(new ContentSearchParameters
			{
				After = date,
				Count = 100, //there will be fewer results than this, we just want to bring them all back
				Filters = new List<string> 
                { 
                    "/music"
                }
			});
			return results;
		}
		public static IEnumerable<MusicModel> GetMusicTypeCountsByDay()
		{
			var results = GetMusicContentForLastNDays(7.0);
			//filter the results to get the ones which are tagged with the musicType tags
			var filtered = results.Results.Where(c => c.TaggedWith.Intersect(MusicTypes).Any());

			//group the results by day with a new collection for each music type
			var grouped = filtered.GroupBy(c => c.PublicationDate)
				.OrderBy(g => g.Key) //g.Key is the publication date, sort by this
				.Select(g => new MusicModel //transform the results 
				{
					Day = g.Key,
					PopAndRock = g.Where(c => c.TaggedWith.Contains(PopAndRock)), //a collection of all the Pop and Rock articles
					Classical = g.Where(c => c.TaggedWith.Contains(Classical)),
					Electronic = g.Where(c => c.TaggedWith.Contains(Electronic)),
					Urban = g.Where(c => c.TaggedWith.Contains(Urban)),
					Folk = g.Where(c => c.TaggedWith.Contains(Folk)),
					WorldMusic = g.Where(c => c.TaggedWith.Contains(WorldMusic)),
					All = g
				});
			
			return grouped;
		}
	}
}
