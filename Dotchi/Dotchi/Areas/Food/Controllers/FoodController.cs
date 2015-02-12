using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dotchi.Areas.Food.Controllers
{
    public class FoodController : Controller
    {
        //
        // GET: /Food/Food/

        public ActionResult Index()
        {
            return View();
        }
    }
}