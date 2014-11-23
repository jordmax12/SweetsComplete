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
        //Session["myIds"] = new Sessio;
        public ActionResult Index(string searchBy, string search, int? page)
        {

            return View(db.products.ToList().ToPagedList(page ?? 1, 6));
        }
        
        public ActionResult Details(int prodID)
        {
            IEnumerable<product> memQuery = db.products.Where(p => p.product_id == prodID);
            return View(memQuery);
        }

        public ActionResult PastPurchases(int userID)
        {
            IEnumerable<fixed_purchases> memQuery = db.fixed_purchases.Where(fp => fp.user_id == userID);
            return View(memQuery);
        }

        public ActionResult SortByHighest(int? page)
        {
            var grabProducts = db.products.OrderByDescending(p => p.price);
            return View(grabProducts.ToList().ToPagedList(page ?? 1, 6));
        }

        public ActionResult SortByLower(int? page)
        {
            var grabProducts = db.products.OrderBy(p => p.price);
            return View(grabProducts.ToList().ToPagedList(page ?? 1, 6));
        }

        public ActionResult SortBySpecial(int? page)
        {
            var grabProducts = db.products.Where(p => p.special == 1).OrderBy(p => p.price);
            return View(grabProducts.ToList().ToPagedList(page ?? 1, 6));
        }

        public ActionResult SortByMost(int? page)
        {
            var mostList = new List<product>();
            var grabProducts = (from p in db.products
                                join fp in db.fixed_purchases
                                on p.product_id equals fp.product_id
                                group p by fp.product_id into g
                                select new { prodID = g.Key, Count = g.Count(), Products = g.Distinct() }
                                    );

             grabProducts.OrderByDescending(x => x.Count).ToList().ForEach(q => q.Products.ToList().ForEach(w => mostList.Add(w)));
             return View(mostList.ToPagedList(page ?? 1, 6));
        }

        public ActionResult SortByLeast(int? page)
        {
            var mostList = new List<product>();
            var grabProducts = (from p in db.products
                                join fp in db.fixed_purchases
                                on p.product_id equals fp.product_id
                                group p by fp.product_id into g
                                select new { prodID = g.Key, Count = g.Count(), Products = g.Distinct() }
                                    );

            grabProducts.OrderBy(x => x.Count).ToList().ForEach(q => q.Products.ToList().ForEach(w => mostList.Add(w)));
            return View(mostList.ToPagedList(page ?? 1, 6));
        }

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

        public ActionResult TestSession(List<int> prodID)
        {
           // List<int> ids = 
                
                //new List<int> { 1, 2, 3, 4, 5 };
            if (Session["myIds"] != null)
            {
                (Session["myIds"] as List<int>).AddRange(prodID);
            }
            else
            {
                Session["myIds"] = prodID;
            }

            //return RedirectToAction("Index");
            return RedirectToAction("ShoppingCart", "Account");
        }

        public ActionResult TestSession2(List<int> prodID)
        {


            if (Session["myIds"] != null)
            {
                (Session["myIds"] as List<int>).AddRange(prodID);
            }
            else
            {
                Session["myIds"] = prodID;
            }

            return RedirectToAction("Index");
        }
    }
}