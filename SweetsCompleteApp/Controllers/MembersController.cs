using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Threading.Tasks;
using PagedList.Mvc;
using PagedList;

namespace SweetsCompleteApp.Controllers
{
    public class MembersController : Controller
    {
        UsersEntities db = new UsersEntities();
        //
        // GET: /Members/
        public ActionResult Index(int? page)
        {
            return View(db.members.ToList().ToPagedList(page ?? 1, 6));
        }

        // GET: /Account/Edit
        [AllowAnonymous]
        public ActionResult ManageUser(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(db.members.ToList());
        }

        // GET: /Account/Edit
        [AllowAnonymous]
        public ActionResult EditUser(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
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