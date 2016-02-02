using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MenuManagementMVC.Context;

namespace MenuManagementMVC.Controllers
{
    public class HomeController : Controller
    {
        RecipeContext db = new RecipeContext();
        public ActionResult Index()
        {
            
            ViewBag.db = "" + db.Database.Connection;
            return View();
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