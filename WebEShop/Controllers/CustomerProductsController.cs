using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebEShop.Data;
using WebEShop.Data.Repositories;
using WebEShop.Models;

namespace WebEShop.Controllers
{
    public class CustomerProductsController : Controller
    {
        private WebEShopDBContext db = new WebEShopDBContext();
        private IGenericRepository<CustomerProduct> repository;
        private IGenericRepository<ProductCategory> categoryRepository;

        public CustomerProductsController()
        {
            repository = new CustomerProductRepository(db);
            categoryRepository = new ProductCategoryRepository(db);
        }

        // GET: CustomerProducts
        public ActionResult Index()
        {
            repository.Add(new CustomerProduct()
            {
                Title = "Dynamic Product 1",
                Description = "Dynamic Product 1 description",
                Price = 25,
                Category = categoryRepository.Get(5)
            });
            return View(db.CustomerProducts.ToList());
        }

        // GET: CustomerProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerProduct customerProduct = db.CustomerProducts.Find(id);
            if (customerProduct == null)
            {
                return HttpNotFound();
            }
            return View(customerProduct);
        }

        // GET: CustomerProducts/Create
        public ActionResult Create()
        {
            var categories = categoryRepository.GetAll();
            //ViewBag.Categories = categories;

            if (categories != null && categories.Count() > 0)
            {
                //var myFirstSelectListItem = new SelectListItem()
                //{
                //    Disabled = false,
                //    Group = new SelectListGroup(),
                //    Selected = true,
                //    Text = $"{categories.FirstOrDefault().Id} {categories.FirstOrDefault().Title}",
                //    Value = categories.FirstOrDefault().Id.ToString()
                //};

                var selectListOfCategories = new List<SelectListItem>();
                //var x = new SelectList(parameters);
                //selectListOfCategories.Add(myFirstSelectListItem);

                var group = new SelectListGroup();
                foreach (var category in categories)
                {
                    var selectListItem = new SelectListItem()
                    {
                        Disabled = false,
                        Group = group,
                        Selected = false,
                        Text = $"{category.Id} {category.Title}",
                        Value = category.Id.ToString()
                    };
                    selectListOfCategories.Add(selectListItem);
                }
                selectListOfCategories.ElementAt(0).Selected = true;
                ViewData.Add("Category", selectListOfCategories);
                //ViewBag.Categories = selectListOfCategories;
            }

            return View();
        }

        // POST: CustomerProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,Price")] CustomerProduct customerProduct, [Bind(Include = "Category")]int Category)
        {
            if (ModelState.IsValid)
            {
                //db.CustomerProducts.Add(customerProduct);
                //db.SaveChanges();
                // get the Category Id and assign a Category to Category prperty of the customerProduct
                customerProduct.Category = categoryRepository.Get(Category);
                //repository.Add(customerProduct); // comes from IGenericRepository
                var dbProduct = (repository as CustomerProductRepository).Add(customerProduct, Category); // new product BUT the Category DOESN'T KNOW IT
                dbProduct.Category.Products.Add(dbProduct); // PLEASE FIX ME // fill the column(field) ProductCategory_Id with the product id
                return RedirectToAction("Index");
            }

            return View(customerProduct);
        }

        // GET: CustomerProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerProduct customerProduct = db.CustomerProducts.Find(id);
            if (customerProduct == null)
            {
                return HttpNotFound();
            }
            return View(customerProduct);
        }

        // POST: CustomerProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,Price")] CustomerProduct customerProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerProduct);
        }

        // GET: CustomerProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerProduct customerProduct = db.CustomerProducts.Find(id);
            if (customerProduct == null)
            {
                return HttpNotFound();
            }
            return View(customerProduct);
        }

        // POST: CustomerProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerProduct customerProduct = db.CustomerProducts.Find(id);
            db.CustomerProducts.Remove(customerProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
