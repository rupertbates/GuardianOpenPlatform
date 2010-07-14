using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Guardian.OpenPlatform;

namespace OpenPlatformDemo.Controllers
{
    public class AuthorController : Controller
    {
        //
        // GET: /Author/

        public ActionResult Index()
        {
            //Get a list of authors with a count for each
            var op = new OpenPlatformSearch();
            var date = DateTime.Today.AddDays(-10.0);
            var results = op.Search(new ContentSearchParameters
            {
                After = date,
                Count = 100,
                Filters = new List<string> { "/global/albumreview" }
            });
            
           
            return View(ResultsHelper.GetCountByDay(results.Results));
        }

    }
}
