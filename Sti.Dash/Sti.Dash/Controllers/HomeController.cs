using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sti.Dash.Controllers
{
    public class HomeController : Controller
    {

        private DashboardContext db = new DashboardContext();
        public ActionResult Index()
        {
            var slideshows = db.Slideshows.ToList();

            return View(slideshows);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}