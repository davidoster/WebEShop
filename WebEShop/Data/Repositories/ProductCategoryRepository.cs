using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebEShop.Models;

namespace WebEShop.Data.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private DbContext _dbContext;

        public ProductCategoryRepository(WebEShopDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddCategory(ProductCategory category)
        {
            using (var db = _dbContext as WebEShopDBContext)
            {
                db.ProductCategories.Add(category);
                db.SaveChanges();
            }
        }

        public IEnumerable<ProductCategory> GetAllCategories()
        {
            using (var db = _dbContext as WebEShopDBContext)
            {
                return db.ProductCategories.ToList();
            }
        }

        public ProductCategory GetCategory(int id)
        {
            using (var db = _dbContext as WebEShopDBContext)
            {
                var category = db.ProductCategories.Find(id);
                return category;
            }
        }

        public bool RemoveCategory(int id)
        {
            bool result = false;
            var category = GetCategory(id);
            if (category != null)
            {
                using (var db = _dbContext as WebEShopDBContext)
                {
                    db.ProductCategories.Remove(category);
                    db.SaveChanges();
                    result = true;
                }
            }
            return result;
        }

        public void UpdateCategory(int id, ProductCategory category)
        {
            var dbCategory = GetCategory(id);
            //dbCategory = category;
            
        }
    }
}