using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEShop.Controllers
{
    public class ProductCategoriesController : Controller
    {
        // GET: ProductCategories
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult List()
        {
            List<string> listOfProductCategories = new List<string>();
            listOfProductCategories.Add(
                new { Id = 1, Title = "Pen", Description = "Pen Description" }.ToString());
            listOfProductCategories.Add(
                new { Id = 2, Title = "Pencil", Description = "Pencil Description" }.ToString());
            ViewBag.ProductCategories = listOfProductCategories;
            return View();
        }

        public ActionResult Details() 
        {

            return null;
        
        }
    }
}