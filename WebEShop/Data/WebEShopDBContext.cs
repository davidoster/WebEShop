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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<ProductCategory>().Property(p => p.Description).IsOptional();
            //modelBuilder.Entity<CustomerProduct>()
            //    .HasRequired<ProductCategory>(c => c.Category).WithMany().WillCascadeOnDelete(true);
            modelBuilder.Entity<ProductCategory>()
                .HasMany<CustomerProduct>(product => product.Products).WithOptional().WillCascadeOnDelete(true);

        }
    }
}