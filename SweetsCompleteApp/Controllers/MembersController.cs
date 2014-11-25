using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Threading.Tasks;
using PagedList.Mvc;
using PagedList;
using SweetsCompleteApp.ViewModel;

namespace SweetsCompleteApp.Controllers
{
    public class MembersController : Controller
    {
        UsersEntities db = new UsersEntities();
        //
        // GET: /Members/
        public ActionResult Index(int? page)
        {
            if (Request.Params["query"] != null)
            {
                string query = Request.Params["query"];
                var grabMembers = db.members.Where(m => m.name.Contains(query) || m.state_province.Contains(query) || m.country.Contains(query) || m.address.Contains(query) || m.country.Contains(query));
                return View(grabMembers.ToList().ToPagedList(page ?? 1, 6));
            }
            else
            {
                return View(db.members.ToList().ToPagedList(page ?? 1, 6));
            }
            
            
        }

        // GET: /Account/Edit
        [AllowAnonymous]
        public ActionResult ManageUser(string returnUrl, int? page)
        {
            ViewBag.ReturnUrl = returnUrl;

            if (Request.Cookies["user"] != null)
            {
                string user = Request.Cookies["user"].Value.ToString();
                var grabMems =
                    from m in db.members
                    join fp in db.fixed_purchases on m.user_id equals fp.user_id
                    join p in db.products on fp.product_id equals p.product_id
                    where m.email == user
                    select new ManageFPViewModel { fixed_purchases = fp, member = m, product = p };

                return View(grabMems.ToList().ToPagedList(page ?? 1, 4));
            }
            else
            {
                return View(db.members.ToList());
            }
            
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