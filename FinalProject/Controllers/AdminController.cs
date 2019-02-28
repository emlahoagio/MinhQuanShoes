using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                ViewData["Products"] = Product.GetAllProduct();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        // GET: Products details
        public ActionResult Detail(int id)
        {
            ViewData["id"] = id;
            Product product = Product.GetAllProductDetail(id);
            if (product != null)
                ViewData["product"] = product;
            return View();
            
        }

        [HttpPost]
        public ActionResult Update(Product product)
        {
            if (product.Image != null)
            {
                string pic = System.IO.Path.GetFileName(product.Image.FileName);
                pic = product.ID + ".jpg";
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~"), "Static/images/products/", pic);
                // file is uploaded
                product.Image.SaveAs(path);
            }
                if (Product.updateProduct(product))
            {
                ViewBag.message = $"Product {product.Name} updated successfully";
                ViewBag.color = "green";
            }
            else
            {
                ViewBag.message = $"Product {product.Name} updated failed";
                ViewBag.color = "red";
            }

            ViewData["product"] = product;
            return View("Detail");
        }
        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (Product.addProduct(product))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = $"Error adding new product";
                ViewBag.color = "red";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (Product.deleteProduct(id))
            {
                ViewBag.color = "green";
                ViewBag.message = $"Product with ID {id} deleted successful";
            }
            else
            {
                ViewBag.color = "red";
                ViewBag.message = "Error Deleting";
            }
            ViewData["Products"] = Product.GetAllProduct();
            return View("Index");
        }
    }
}