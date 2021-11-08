using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using WebProductsMVC.Models;
using WebProductsMVC.Data;

namespace WebProductsMVC.Admin
{
    static public class AdmProduct
    {
        static ProductDbContext context = new ProductDbContext();

        public static List<Product> Listar()
        {
            return context.Products.ToList();
        }

        public static List<Product> ListarPorCategoria(string categoria)
        {
            var products = (from p in context.Products
                            where p.Category == categoria
                            select p).ToList();
            return products;
        }

        public static List<Product> ListarPorNombre(string nombre)
        {
            var products = (from p in context.Products
                            where p.ProductName == nombre
                            select p).ToList();
            return products;
        }

        public static List<Product> ListarPorNombreYCategoria(string nombre, string categoria)
        {
            var products = (from p in context.Products
                            where p.ProductName == nombre &&
                            p.Category == categoria
                            select p).ToList();
            return products;
        }

        public static Product TraerPorID(int id)
        {
            Product product = context.Products.Find(id);
            context.Entry(product).State = EntityState.Detached;
            return product;
        }

        public static void Insertar ( Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public static void Eliminar(Product product)
        {
            if (!context.Products.Local.Contains(product))
            {
                context.Products.Attach(product);
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }

        public static void Editar(Product product)
        {
            context.Products.Attach(product);
            context.Entry(product).State = EntityState.Modified;
            context.SaveChanges();
        }

    }
}