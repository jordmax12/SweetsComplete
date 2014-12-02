using SweetsCompleteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using Microsoft.Ajax.Utilities;

namespace SweetsCompleteApp.Controllers
{
    public class ProductsController : Controller
    {
        UsersEntities db = new UsersEntities();
        //Session["myIds"] = new Sessio;
        public ActionResult Index(string searchBy, string search, int? page)
        {
            if(Request.Params["query"] == "SortByLowest")
            {
                var grabProducts = db.products.OrderBy(p => p.price);
                return View(grabProducts.ToList().ToPagedList(page ?? 1, 6));
            }
            else if (Request.Params["query"] == "SortByHighest")
            {

                var grabProducts = db.products.OrderByDescending(p => p.price);
                return View(grabProducts.ToList().ToPagedList(page ?? 1, 6));
            }
            else if (Request.Params["query"] == "SortByMost")
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
            else if (Request.Params["query"] == "SortByLeast")
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
            else if (Request.Params["query"] == "SortBySpecial")
            {
                var grabProducts = db.products.Where(p => p.special == 1).OrderBy(p => p.price);
                return View(grabProducts.ToList().ToPagedList(page ?? 1, 6));
            }
            else
            {
                return View(db.products.ToList().ToPagedList(page ?? 1, 6));
            }

            
        }
        
        public ActionResult Details(int prodID)
        {
            IEnumerable<product> memQuery = db.products.Where(p => p.product_id == prodID);
            return View(memQuery);
        }

        public ActionResult PastPurchases(int userID, int? page)
        {
            var memQuery = db.fixed_purchases.Where(fp => fp.user_id == userID);

            if(Request.Params["filter"] != null)
            {
                if (Request.Params["filter"] == "SortByRecent")
                {
                    var newMemQuery = db.fixed_purchases.Where(fp => fp.user_id == userID).OrderByDescending(fp => fp.date);
                    return View(newMemQuery.ToList().ToPagedList(page ?? 1, 10));
                }
                else if (Request.Params["filter"] == "OppSortByRecent")
                {
                    var newMemQuery = db.fixed_purchases.Where(fp => fp.user_id == userID).OrderBy(fp => fp.date);
                    return View(newMemQuery.ToList().ToPagedList(page ?? 1, 10));
                }
                else
                {
                    return View(memQuery.ToList().ToPagedList(page ?? 1, 10));
                }
                
            }
            else
            {
                
                return View(memQuery.ToList().ToPagedList(page ?? 1, 10));
            }

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

        public ActionResult ShoppingCartController(List<int> prodID)
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
    }
}