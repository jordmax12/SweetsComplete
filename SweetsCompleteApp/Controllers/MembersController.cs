using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Threading.Tasks;

namespace SweetsCompleteApp.Controllers
{
    public class MembersController : Controller
    {
        UsersEntities db = new UsersEntities();
        //
        // GET: /Members/
        public ActionResult Index()
        {
            return View(db.members.ToList());
        }

        //
        // GET: /Account/Edit
        [AllowAnonymous]
        public ActionResult EditProfile(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Edit
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> EditProfile()
        {
            /*var temp = new HttpCookie("user");
            temp.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(temp);*/
            //using (member ctx = new EntertainmentAgencyExampleEntities())
            
            return RedirectToAction("Index", "Home");
        }
    
	}
}