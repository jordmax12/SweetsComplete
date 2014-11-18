using SweetsCompleteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace SweetsCompleteApp.Controllers
{
    public class ProductsController : Controller
    {
        UsersEntities db = new UsersEntities();


        public ActionResult Index(string searchBy, string search, int? page)
        {
            /*string submit for params if i use below code
             * 
             * string fixedurl = Request.RawUrl.Split(new[] { '?' })[0];
            string newParam = Request.Params["page"] ?? "0";;
            int getPageNum = Convert.ToInt32(newParam);

            switch (submit)
            {

                case "prev":
                    // Do something

                    Response.Redirect(fixedurl + "?page=" + (getPageNum - 1));
                    break;
                case "next":
                    // Do something
                    Response.Redirect(fixedurl + "?page=" + (getPageNum + 1));
                    break;
                default:
                    //throw new Exception();
                    break;
            }
             *return View(db.products.ToList());
             *
             */

            return View(db.products.ToList().ToPagedList(page ?? 1, 6));

        }

        /*[HttpGet]
        public ActionResult Details()
        {
            return View();
        }
        [HttpPost]*/
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(product product)
        {
            if(ModelState.IsValid)
            {
                db.products.Add(product);
                db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }
        // GET: Products
        public ActionResult Products2()
        {
            Products product = new Products();
            product.title = "Fudge";
            product.sku = "F1000";
            product.description = "Invenire percipitur eum ea, in saepe persequeris has, meis dicta albucius an vix. Utinam nonumes necessitatibus vel ne. Ad mea tacimates temporibus. Duo dicam timeam integre in. Ius an libris latine, ludus inimicus quo te, ridens scripta placerat in pri. Nec ex feugiat abhorreant.\r\n";
            product.price = .10f;
            product.special = 1;
            product.link = "95_2542284";

            Products choco = new Products();
            choco.title = "Chocolate";
            choco.sku = "A2005";
            choco.description = "chocolate is good its very good it tastes like chocolate yay it's chocolate because it's chocolate and it's dark like chocolate.\r\n";
            choco.price = .30f;
            choco.special = 1;
            choco.link = "95_2542284";

            Products vanilla = new Products();
            vanilla.title = "Vanilla";
            vanilla.sku = "B4202";
            vanilla.description = "vanilla is good its very good it tastes like vanilla yay it's vanilla because it's vanilla and it's white like vanilla.\r\n";
            vanilla.price = .20f;
            vanilla.special = 1;
            vanilla.link = "95_2542284";

            List<Products> prods = new List<Products>();
            prods.Add(product);
            prods.Add(choco);
            prods.Add(vanilla);

            return View(prods);
        }
    }
}