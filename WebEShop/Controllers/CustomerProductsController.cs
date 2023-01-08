using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebEShop.Data;
using WebEShop.Data.Repositories;
using WebEShop.Models;

namespace WebEShop.Controllers
{
    public class CustomerProductsController : Controller
    {
        private WebEShopDBContext _db = new WebEShopDBContext();
        private IGenericRepository<CustomerProduct> _repository;
        private IGenericRepository<ProductCategory> _categoryRepository;

        public CustomerProductsController()
        {
            _repository = new CustomerProductRepository(_db);
            _categoryRepository = new ProductCategoryRepository(_db);
        }

        // GET: CustomerProducts
        public ActionResult Index()
        {
            return View(_db.CustomerProducts.ToList());
        }

        // GET: CustomerProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerProduct customerProduct = _db.CustomerProducts.Find(id);
            if (customerProduct == null)
            {
                return HttpNotFound();
            }
            return View(customerProduct);
        }

        // GET: CustomerProducts/Create
        public ActionResult Create()
        {
            var categories = _categoryRepository.GetAll();
            if (categories == null || categories.Count() <= 0) return View();
            var selectListOfCategories = new List<SelectListItem>();
            var group = new SelectListGroup();
            foreach (var category in categories)
            {
                var selectListItem = new SelectListItem()
                {
                    Disabled = false,
                    Group = group,
                    Selected = false,
                    Text = $@"{category.Id} {category.Title}",
                    Value = category.Id.ToString()
                };
                selectListOfCategories.Add(selectListItem);
            }
            selectListOfCategories.ElementAt(0).Selected = true;
            ViewData.Add("Category", selectListOfCategories);
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
                customerProduct.Category = _categoryRepository.Get(Category);
                var dbProduct = (_repository as CustomerProductRepository).Add(customerProduct, Category); // new product BUT the Category DOESN'T KNOW IT
                // DELETE THIS LINE!!! It is not needed anymore!!!! //dbProduct.Category.Products.Add(dbProduct); // PLEASE FIX ME // fill the column(field) ProductCategory_Id with the product id
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
            CustomerProduct customerProduct = _db.CustomerProducts.Find(id);
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
                _db.Entry(customerProduct).State = EntityState.Modified;
                _db.SaveChanges();
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
            CustomerProduct customerProduct = _db.CustomerProducts.Find(id);
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
            CustomerProduct customerProduct = _db.CustomerProducts.Find(id);
            _db.CustomerProducts.Remove(customerProduct);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
