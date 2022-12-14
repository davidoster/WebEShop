using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebEShop.Models
{
    public class CustomerProduct
    {
        public int Id { get; set; } // Id (Primary key)
        public string Title { get; set; } // Title
        public string Description { get; set; } // Description
        public double Price { get; set; } // Price
        //public int Product_CategoryId { get; set; } // Category_Id
        public virtual ProductCategory Category { get; set; }
    }
}