using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEShop.Data;
using WebEShop.Models;

namespace WebEShop.Controllers
{
    public class ProductCategoriesController : Controller
    {
        private WebEShopDBContext context;

        public ProductCategoriesController()
        {
            context = new WebEShopDBContext();
        }
        // GET: ProductCategories
        public ActionResult Index()
        {
            context.ProductCategories.Add(new ProductCategory()
            {
                Title = "Pen",
                Description = "Pen Description",
                Products = new List<CustomerProduct>()
                {
                    new CustomerProduct()
                    {
                        Title = "Red Pen",
                        Description = "Red Pen Description",
                        Price = 10.45
                    },
                    new CustomerProduct()
                    {
                        Title = "Blue Pen",
                        Description = "Blue Pen Description",
                        Price = 10.45
                    }
                }
            });
            context.SaveChanges();
            return View();
        }

        public ViewResult MyDummyList()
        {
            var listOfProductCategories = context.ProductCategories.ToList();
            //int idOfFirstProductOnCat0 = listOfProductCategories[0].Products.ToList()[0].Id;
            
            ViewBag.ProductCategories = listOfProductCategories;
            return View();
        }

        public ViewResult List()
        {
            return View(context.ProductCategories.AsEnumerable<ProductCategory>()); //as IEnumerable<ProductCategory>);
        }
        public ActionResult Details(int id) 
        {
            return View(context.ProductCategories.Find(id));
        }

        public ActionResult Delete(int id)
        {
            //var productCategoryToBeDeleted = context.ProductCategories.Find(id);
            //if(productCategoryToBeDeleted != null)
            //{
            //    context.ProductCategories.Remove(productCategoryToBeDeleted);
            //}

            using (var productCategoryToBeDeleted1 = context.ProductCategories.Find(id))
            {
                try
                {
                    context.ProductCategories.Remove(productCategoryToBeDeleted1);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index?message=Product Category was not found!", "Home");
                    //return ex.Message;
                    //throw new NotFoundEntityException(ex.Message);
                }
                return RedirectToAction($"List?message=ProductCategory with {id} is deleted succesfully!");
                //return "Deleted!";
                
            }
        }
    }
}