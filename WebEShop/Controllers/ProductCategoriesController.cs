using System.Linq;
using System.Web.Mvc;
using WebEShop.Data;
using WebEShop.Data.Repositories;
using WebEShop.Models;

namespace WebEShop.Controllers
{
    public class ProductCategoriesController : Controller
    {
        private WebEShopDBContext _context;
        private ProductCategoryRepository _repository;

        public ProductCategoriesController()
        {
            _context = new WebEShopDBContext(); // WITHOUT UoW
            _repository = new ProductCategoryRepository(_context); // WITHOUT UoW
        }

        // HTTP CLASSICAL METHODS: POST(C), GET(R), PUT(U), DELETE(D)
        // GET: ProductCategories
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(ProductCategory productCategory)
        {
            string created = "created";
            string updated = "updated";
            string result = "";
            result = productCategory.Id == 0 ? created : updated;
            _repository.Add(productCategory);
            return RedirectToAction("List", 
                new { message = $"A New Product Category is been {result} successfully!" });
        }

        public ViewResult List(string message)
        {
            ViewBag.Message = message;
            var categories = _repository.GetAll();   // unit.Category.GetAll();
            return View(categories);
        }

        public ActionResult Details(int id)
        {
            _context = new WebEShopDBContext(); // WITHOUT UoW
            _repository = new ProductCategoryRepository(_context);
            using (var category = _repository.Get(id))
            {
                if(category != null && category.Products != null)
                {
                    var products = category.Products.ToList();
                    if(products.Count > 0)
                    {
                        ViewData.Add("ProductsList", products); // ViewBag.Products = products;
                    }
                    return View(category);
                }
                ViewBag.Result = $"No ProductCategory exists with id = {id}";
                return View();
            }
            
        }

        public ActionResult Delete(int id)
        {
            if(_repository.Remove(id))
            {
                string path = $"ProductCategory with id {id} is deleted successfully!";
                return RedirectToAction("List", new { message = path });
            }
            return RedirectToAction("Index", "Home", 
                new { message = $"Product Category with id {id} was not found!" });
        }

        public ActionResult Edit(int id)
        {
            return View(_repository.Get(id));
        }
    }
}