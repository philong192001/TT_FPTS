using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace _3Tier.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductBLL _dB;      
        public ProductController(ProductBLL db)
        {
            _dB = db;
           
        }         
        public IActionResult Index()
        {
            List<Product> products = new List<Product>();
            products = _dB.GetAllProduct().ToList();
            return View(products);
        }
        public IActionResult Create()
        {
            var listCate = _dB.AllCategory();
            var listBrand = _dB.AllBrand();          
            ViewBag.listBrand = listBrand;           
            ViewBag.listCate = listCate;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Product product)
        {
            if (ModelState.IsValid)
            {
                _dB.AddProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = _dB.GetProductById(id);
            var listCate = _dB.AllCategory();
            var listBrand = _dB.AllBrand();
            dynamic data = new ExpandoObject();
            data.product = product;
            data.list_brand = listBrand;
            data.list_categories = listCate;
            if (product == null)
            {
                return NotFound();
            }
            //return View(data);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _dB.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            return View(_dB);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = _dB.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = _dB.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            _dB.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
