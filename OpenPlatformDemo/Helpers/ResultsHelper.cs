using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Guardian.OpenPlatform;

namespace OpenPlatformDemo
{
    public class ResultsHelper
    {
        public static Dictionary<string, int> GetContentTypeCounts(Content[] results)
        {
            var grouped = results.GroupBy(c => c.Type);
            var dict = grouped.ToDictionary(k => k.Key, v=> v.Count());
            return dict; 

        }
        public static Dictionary<string, int> GetCountByDay(Content[] results)
        {
            return results
                .GroupBy(c => (c.PublicationDate.DayOfWeek.ToString()))
                .ToDictionary<IGrouping<string, Content>, string, int>(g => g.Key, g => g.Count());
        }
		
    }
}
