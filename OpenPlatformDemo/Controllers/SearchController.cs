using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Guardian.OpenPlatform;

namespace OpenPlatformDemo.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Results(ContentSearchParameters parameters)
        {
            OpenPlatformSearch op = new OpenPlatformSearch();
            var results = op.Search(parameters);
            return View(results);
        }

    }
}
