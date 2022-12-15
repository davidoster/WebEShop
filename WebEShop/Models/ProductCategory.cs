using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebEShop.Models
{
    public class ProductCategory: IDisposable
    {
        public int Id { get; set; } // Id (Primary key)
        [DisplayName("Product Title")]
        public string Title { get; set; } // Title
        public string Description { get; set; } // Description
        public virtual ICollection<CustomerProduct> Products { get; set; }

        public void Dispose()
        {

        }
    }
}