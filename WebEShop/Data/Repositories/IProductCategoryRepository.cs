using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebEShop.Models;

namespace WebEShop.Data.Repositories
{
    internal interface IProductCategoryRepository
    {
        ProductCategory Add(ProductCategory entity, int id);

    }
}
