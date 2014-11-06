using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SweetsCompleteApp.Models
{
    public class Products
    {
        public int productID { get; set; }
        public string sku { get; set; }
        public string title{ get; set; }
        public string description { get; set; }
        public float price { get; set; }
        public int special { get; set; }
        public string link { get; set; }
    }
}