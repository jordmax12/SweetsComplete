using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;

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
    
	}
}