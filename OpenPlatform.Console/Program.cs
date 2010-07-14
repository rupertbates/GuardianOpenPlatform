using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Guardian.OpenPlatform;
using Guardian.OpenPlatform.EqualityComparers;

namespace OpenPlatform.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimpleSearch();
            //SearchWithFilters();
            //GetItem();
            //GetDistinctItemTypes();
            //GetMusicReviews();
            GetMusicReviewsByDate();

            Console.In.Read();
        }

        private static void GetMusicReviewsByDate()
        {
            //Get a list of authors with a count for each
            var op = new OpenPlatformSearch();
            var results = op.Search(new ContentSearchParameters
            {
                Count = 100,
                Filters = new List<string> { "/global/albumreview" }
            });

            var byDate = results.Results
                .GroupBy(c => c.PublicationDate)
                .Select(c => new { date = c.Key, Count = c.Count() });
            foreach (var item in byDate)
            {
                Console.WriteLine("Date: " + item.date + " Day: " + item.date.DayOfWeek + " Count: " + item.Count);
            }

        }

        private static void GetMusicReviews()
        {
            //Get a list of different content types with a count for each
            var op = new OpenPlatformSearch();
            var results = op.Search(new ContentSearchParameters { Count = 100, Filters = new List<string> {"/global/albumreview" } });
            var types = results.Results
                .Select(c => c.TaggedWith.Where(t => t.Type == "keyword"))
                .SelectMany(i => i)
                .Distinct(new TagComparer());
            foreach (var item in types)
            {
                Console.WriteLine(item.Name);
            }
            var typeCounts = results.Results
                .Where(c => c.TaggedWith.Any(t => t.Type == "keyword" && t.Name.Contains("music")))
                .GroupBy(c => (c.TaggedWith.First(t => t.Name.Contains("music")).Name))
                .Select(c => new { ContentType = c.Key, Count = c.Count() });

            foreach (var typeCount in typeCounts)
            {
                Console.WriteLine("Type: " + typeCount.ContentType + " Count: " + typeCount.Count);
            }

            var authorCounts = results.Results
                .GroupBy(c => (c.Byline))
                .Select(c => new { ContentType = c.Key, Count = c.Count() });

            foreach (var typeCount in authorCounts)
            {
                Console.WriteLine("Type: " + typeCount.ContentType + " Count: " + typeCount.Count);
            }
        }

        private static void GetDistinctItemTypes()
        {
            //Get a list of different content types with a count for each
            var op = new OpenPlatformSearch();
            var results = op.Search(new ContentSearchParameters {Count = 100});

            var typeCounts = results.Results
                .GroupBy(c => c.Type)
                .Select(c => new {ContentType = c.Key, Count = c.Count()});

            foreach(var typeCount in typeCounts)
            {
                Console.WriteLine("Type: " + typeCount.ContentType + " Count: " + typeCount.Count);
            }
        }
        protected static void SimpleSearch()
        {
            //A simple content search
            var op = new OpenPlatformSearch();
            var results = op.Search(new ContentSearchParameters
            {
                Query = "Nina Nastasia",
                Count = 20,
            });
            Console.WriteLine("Number of results: " + results.Count);
            foreach (var item in results.Results)
            {
                Console.WriteLine(item.Headline);
            }   
        }
        protected static void SearchWithFilters()
        {
            //A content search with filters
            var op = new OpenPlatformSearch();
            var parameters = new ContentSearchParameters
                                 {
                                     Query = "prince",
                                     Count = 20,
                                     Filters = new List<string>{"music"}
                                 };
            
            var results = op.Search(parameters);

            Console.WriteLine("Number of results: " + results.Count);
            foreach (var item in results.Results)
            {
                Console.WriteLine(item.Headline);
            }
        }
        protected static void GetItem()
        {
            //Get an item by Id
            var op = new OpenPlatformSearch();
            var item = op.Item(353757375);
            Console.WriteLine("author name: " + item.Byline);
            if(item.Type == "article")
                Console.WriteLine(item.TypeSpecific.Body);
        }
    }
}
