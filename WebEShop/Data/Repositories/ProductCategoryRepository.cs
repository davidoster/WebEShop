using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WebEShop.Models;

namespace WebEShop.Data.Repositories
{
    public class ProductCategoryRepository : IGenericRepository<ProductCategory>
    {
        private DbContext _dbContext;

        public ProductCategoryRepository(WebEShopDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(ProductCategory category)
        {
            using (var db = _dbContext as WebEShopDBContext)
            {
                db.ProductCategories.AddOrUpdate(category);
                //db.SaveChanges();
            }
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            using (var db = _dbContext as WebEShopDBContext)
            {
                return db.ProductCategories.ToList();
            }
        }

        public ProductCategory Get(int id)
        {
            using (var db = _dbContext as WebEShopDBContext)
            {
                var category = db.ProductCategories.Find(id);
                return category;
            }
        }

        public bool Remove(int id)
        {
            bool result = false;
            var category = Get(id);
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

        public void Update(int id, ProductCategory category)
        {
            var dbCategory = Get(id);
            //dbCategory = category;
            
        }
    }
}