﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebEShop.Models;

namespace WebEShop.Data.Repositories
{
    internal interface IProductCategoryRepository
    {
        ProductCategory GetCategory(int id);
        IEnumerable<ProductCategory> GetAllCategories();
        void AddCategory(ProductCategory category);
        bool RemoveCategory(int id);
        void UpdateCategory(int id, ProductCategory category);

    }
}