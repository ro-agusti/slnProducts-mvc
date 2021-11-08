using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using WebProductsMVC.Models;

namespace WebProductsMVC.Data
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(): base("KeyDb") { }
        public DbSet<Product> Products { get; set; }
    }
}