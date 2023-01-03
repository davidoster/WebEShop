using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebEShop.Models;

namespace WebEShop.Data.Repositories
{
    public interface IGenericRepository<T> where T: class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        bool Remove(int id);
        void Update(int id, T entity);
    }
}
