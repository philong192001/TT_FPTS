using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace _3Tier.Controllers
{
    public class ProductController : Controller
    {
        ConnectDB dB = new ConnectDB();
        public IActionResult Index()
        {
            List<Product> products = new List<Product>();
            products = dB.GetAllProduct().ToList();
            return View(products);
        }
        public IActionResult Create()
        {       
            List<Brand> list_brand = new List<Brand>();
            DataSet ds1 = dB.SelectBrand();
            foreach (DataRow dr in ds1.Tables[0].Rows)
            {
                Brand brand = new Brand();
                brand.id = Convert.ToInt32(dr["id"]);
                brand.name = dr["name"].ToString();
                list_brand.Add(brand);
            }
            ViewBag.listBrand = list_brand;
            List<Category> list_categories = new List<Category>();
            DataSet ds2 = dB.SelectCate();
            foreach (DataRow dr in ds2.Tables[0].Rows)
            {
                Category category = new Category();
                category.id = Convert.ToInt32(dr["id"]);
                category.name = dr["name"].ToString();
                list_categories.Add(category);
            }
            ViewBag.listCate = list_categories;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Product product)
        {
            if (ModelState.IsValid)
            {
               dB.AddProduct(product);
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
           
            Product product = dB.GetProductById(id);
            List<Brand> list_brand = new List<Brand>();
            DataSet ds1 = dB.SelectBrand();
            foreach (DataRow dr in ds1.Tables[0].Rows)
            {
                Brand brand = new Brand();
                brand.id = Convert.ToInt32(dr["id"]);
                brand.name = dr["name"].ToString();
                list_brand.Add(brand);
            }
            List<Category> list_categories = new List<Category>();
            DataSet ds2 = dB.SelectCate();
            foreach (DataRow dr in ds2.Tables[0].Rows)
            {
                Category category = new Category();
                category.id = Convert.ToInt32(dr["id"]);
                category.name = dr["name"].ToString();
                list_categories.Add(category);
            }
            dynamic data = new ExpandoObject();
            data.product = product;
            data.list_brand = list_brand;
            data.list_categories = list_categories;
            if (product == null)
            {
                return NotFound();
            }
            return View(data);
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
                dB.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            return View(dB);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = dB.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        public IActionResult Delete(int? id )
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = dB.GetProductById(id);

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
            dB.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
