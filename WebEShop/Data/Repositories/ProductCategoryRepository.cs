using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WebEShop.Models;

namespace WebEShop.Data.Repositories
{
    public class ProductCategoryRepository : IGenericRepository<ProductCategory>, IProductCategoryRepository
    {
        private DbContext _dbContext;

        public ProductCategoryRepository(WebEShopDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ProductCategory Add(ProductCategory category)
        {
            var db = _dbContext as WebEShopDBContext;
            db.ProductCategories.AddOrUpdate(category);
            db.SaveChanges();
            return category;
            //using (var db = _dbContext as WebEShopDBContext)
            //{
            //    db.ProductCategories.AddOrUpdate(category);
            //    db.SaveChanges();
            //}
        }

        public ProductCategory Add(ProductCategory entity, int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            var db = _dbContext as WebEShopDBContext;
            return db.ProductCategories.ToList();
            //using (var db = _dbContext as WebEShopDBContext)
            //{
            //    return db.ProductCategories.ToList();
            //}
        }

        public ProductCategory Get(int id)
        {
            var db = _dbContext as WebEShopDBContext;
            var category = db.ProductCategories.Find(id);
            return category;
            //using (var db = _dbContext as WebEShopDBContext)
            //{
            //    var category = db.ProductCategories.Find(id);
            //    return category;
            //}
        }

        public bool Remove(int id)
        {
            bool result = false;
            var category = Get(id);
            if (category != null)
            {
                var db = _dbContext as WebEShopDBContext;
                db.ProductCategories.Remove(category);
                db.SaveChanges();
                result = true;
                //using (var db = _dbContext as WebEShopDBContext)
                //{
                //    db.ProductCategories.Remove(category);
                //    db.SaveChanges();
                //    result = true;
                //}
            }
            return result;
        }

        public ProductCategory Update(int id, ProductCategory category)
        {
            var dbCategory = Get(id);
            dbCategory = category;
            return dbCategory;
        }

        
    }
}