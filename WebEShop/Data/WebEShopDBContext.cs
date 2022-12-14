using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebEShop.Models;

namespace WebEShop.Data
{
    public class WebEShopDBContext : DbContext
    {
        public WebEShopDBContext(): base("name=WebEShopConnectionString")
        {

        }
        public DbSet<CustomerProduct> CustomerProducts { get; set; } // CustomerProducts
        public DbSet<ProductCategory> ProductCategories { get; set; } // ProductCategories
    }
}