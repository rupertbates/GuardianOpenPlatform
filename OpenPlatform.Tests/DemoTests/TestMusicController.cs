using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Guardian.OpenPlatform.EqualityComparers;

namespace Guardian.OpenPlatform.Tests.DemoTests
{
    [TestFixture]
    public class TestMusicController
    {
        [Test]
        public void Test_result_grouping()
        {
            var op = new OpenPlatformSearch(new Guardian.OpenPlatform.Tests.ApiService("xml\\MusicResults.xml"));
            var results = op.Search(new ContentSearchParameters());
			var popAndRock = new Tag{Filter="/music/popandrock"};
            var classical = new Tag{Filter="/music/classicalmusicandopera"};
            var electronic = new Tag{Filter="/music/electronicmusic"};
            var urban = new Tag{Filter="/music/urban"};
            var folk = new Tag{Filter="/music/folk"};
            var worldmusic = new Tag{Filter="/music/worldmusic"};
            //Get the tags which match with music types
            var musicTypes = new[]
			{
				popAndRock, classical, electronic, urban, folk, worldmusic
            };

            //filter the results to get the ones which are tagged with the musicType tags
            var filtered = results.Results.Where(c => c.TaggedWith.Intersect(musicTypes).Count() > 0);

			Assert.Greater(filtered.Count(), 0);

            //group them by day with a count for each music type
			var grouped = filtered.GroupBy(c => c.PublicationDate.DayOfWeek)
				.OrderBy(g => g.Key)
				.Select(g => new
				{
					DayOfWeek = g.Key,
					PopAndRock = g.Where(c => c.TaggedWith.Contains(popAndRock)).Count(),
					Classical = g.Where(c => c.TaggedWith.Contains(classical)).Count(),
					Electronic = g.Where(c => c.TaggedWith.Contains(electronic)).Count(),
					Urban = g.Where(c => c.TaggedWith.Contains(urban)).Count(),
					Folk = g.Where(c => c.TaggedWith.Contains(folk)).Count(),
					WorldMusic = g.Where(c => c.TaggedWith.Contains(worldmusic)).Count()
				});

            //ResultsHelper.GetCountByDay(results.Results);
			Assert.Greater(grouped.Count(), 0);
        }
        public bool hasTags(Content c, IEnumerable<Tag> tags)
        {

            var intersect = c.TaggedWith.Intersect(tags);
            return intersect.Count() > 0;
        }
    }
}
