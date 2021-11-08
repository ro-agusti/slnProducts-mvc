using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebProductsMVC.Models;
using WebProductsMVC.Data;
using WebProductsMVC.Admin;

namespace WebProductsMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        public ActionResult Index(string category, string name)
        {
            int cat = String.IsNullOrEmpty(category) ? 0 : 2;
            int nam = String.IsNullOrEmpty(name) ? 0 : 1;
            int namCat = String.IsNullOrEmpty(name)|| String.IsNullOrEmpty(category) ? 0 : 3;
            int val = cat | nam | namCat;
            switch (val)
            {
                case 0:
                    return View(AdmProduct.Listar());
                case 2:
                    return View(AdmProduct.ListarPorCategoria(category));
                case 1:
                    return View(AdmProduct.ListarPorNombre(name));
                case 3: 
                    return View(AdmProduct.ListarPorNombreYCategoria(name,category));
                default:
                    return View();
            }
        }

        public ActionResult Create()
        {
            Product product = new Product();
            return View("Create", product);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                AdmProduct.Insertar(product);
                return RedirectToAction("Index");
            }
            return View("Create", product);
            
        }

        public ActionResult Details(int id)
        {
            Product product = AdmProduct.TraerPorID(id);
            if (product != null)
            {
                return View("Details", product);
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult Delete(int id)
        {
            Product product = AdmProduct.TraerPorID(id);
            if (product != null)
            {
                return View("Delete", product);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = AdmProduct.TraerPorID(id);
            AdmProduct.Eliminar(product);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Product product = AdmProduct.TraerPorID(id);
            if (product != null)
            {
                return View("Edit");
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            AdmProduct.Editar(product);
            return RedirectToAction("Index");
        }
    }
}