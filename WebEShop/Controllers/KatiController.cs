using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEShop.Controllers
{
    public class KatiController : Controller
    {
        // GET: KatiController
        [Route("Koukou")]
        [Route("Koukou/Index")]
        public ActionResult Index()
        {
            int i = 10;
            string s = $@"C:\temp\{i}";
            string s1 = @"\d+"; // regular expression
            return View();
        }
    }
}