using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace shopping.Models
{
    public class MvcShoppingContext : DbContext
    {
        public MvcShoppingContext()
            : base("name=DefaultConnection")
        {
        }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Cartcs> Cartcs { get; set; }
        public DbSet<Product2> Products2 { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<OrderHeader> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetailItems { get; set; }
    }

}