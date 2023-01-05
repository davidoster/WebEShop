using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WebEShop.Models;

namespace WebEShop.Data.Repositories
{
    public class CustomerProductRepository : IGenericRepository<CustomerProduct>, ICustomerProductRepository
    {
        private DbContext _dbContext;

        public CustomerProductRepository(WebEShopDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CustomerProduct Add(CustomerProduct entity)
        {
            var db = _dbContext as WebEShopDBContext;
            db.CustomerProducts.AddOrUpdate(entity);
            db.SaveChanges();
            return entity;
        }

        public CustomerProduct Add(CustomerProduct entity, int categoryId)
        {
            var db = _dbContext as WebEShopDBContext;
            var category = db.ProductCategories.Find(categoryId);
            entity.Category = category;
            var product = db.CustomerProducts.Add(entity);
            db.SaveChanges();
            return product;
        }

        public CustomerProduct Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerProduct> GetAll()
        {
            var db = _dbContext as WebEShopDBContext;
            return db.CustomerProducts;
            //return db.CustomerProducts.AsEnumerable();
            //return db.CustomerProducts.ToList();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public CustomerProduct Update(int id, CustomerProduct entity)
        {
            throw new NotImplementedException();
        }
    }
}