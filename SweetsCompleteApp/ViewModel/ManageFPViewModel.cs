using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SweetsCompleteApp.ViewModel
{
    public class ManageFPViewModel
    {
        public fixed_purchases fixed_purchases { get; set; }
        public member member { get; set; }
        public product product { get; set; }
    }
}