using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using WebProductsMVC.Models;

namespace WebProductsMVC.Data
{
    public class ProductInitializer:DropCreateDatabaseAlways<ProductDbContext>
    {
        protected override void Seed(ProductDbContext context)
        {
            var products = new List<Product>
            {
                new Product
                {
                    Category = "Electronics",
                    ProductName = "Sony", 
                    Description = "32'LCD TV",
                    AvailableDate = Convert.ToDateTime("01/01/2020")
                }
            };
            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();
        }
    }
}