using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebEShop.Models;

namespace WebEShop.Data.Repositories
{
    public class CustomerProductRepository : IGenericRepository<CustomerProduct>
    {
        private DbContext _dbContext;

        public CustomerProductRepository(WebEShopDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(CustomerProduct entity)
        {
            throw new NotImplementedException();
        }

        public CustomerProduct Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerProduct> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, CustomerProduct entity)
        {
            throw new NotImplementedException();
        }
    }
}