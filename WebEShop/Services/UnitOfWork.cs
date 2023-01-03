using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebEShop.Data;
using WebEShop.Data.Repositories;
using WebEShop.Models;

namespace WebEShop.Services
{
    public class UnitOfWork : IDisposable
    {

        private WebEShopDBContext _db = new WebEShopDBContext();

        private IGenericRepository<ProductCategory> _categoryRepository;
        private IGenericRepository<CustomerProduct> _productRepository;

        public IGenericRepository<ProductCategory> Category { get; set; }
        public IGenericRepository<CustomerProduct> Product { get; set; }

        public UnitOfWork() 
        { 
           Category = new ProductCategoryRepository((WebEShopDBContext)_db);
           Product = new CustomerProductRepository((WebEShopDBContext)_db);
        }

        public void Save()
        {
            
            _db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}