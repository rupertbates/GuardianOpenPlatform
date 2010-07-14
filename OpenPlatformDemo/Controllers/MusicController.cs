using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Guardian.OpenPlatform;
using OpenPlatformDemo.Services;

namespace OpenPlatformDemo.Controllers
{
    public class MusicController : Controller
    {
        //
        // GET: /Music/

        public ActionResult Index()
        {
			var model = MusicService.GetMusicTypeCountsByDay();
            return View(model);
        }

    }
}
