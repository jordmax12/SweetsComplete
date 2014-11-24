using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace SweetsCompleteApp.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        UsersEntities db = new UsersEntities();
        public ActionResult Index(int? page)
        {
            var grabProducts = db.products.Where(p => p.special == 1).OrderBy(p => p.price);
            return View(grabProducts.ToList().ToPagedList(page ?? 1, 3));
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}