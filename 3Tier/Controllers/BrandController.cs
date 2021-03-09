using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace _3Tier.Controllers
{
    public class BrandController : Controller
    {
        private readonly BrandBLL _dB;
        public BrandController(BrandBLL db)
        {
            _dB = db;
        }
        public IActionResult Index()
        {
            //List<Brand> brands = new List<Brand>();
            var brands = _dB.GetBrand().ToList();
            return View(brands);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Brand brand)
        {
            if (ModelState.IsValid)
            {
                _dB.AddBrand(brand);
                return RedirectToAction("Index");
            }
            return View(brand);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Brand brand = _dB.GetBrandById(id);

            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            _dB.DeleteBrand(id);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Brand brand = _dB.GetBrandById(id);
           
            if (brand == null)
            {
                return NotFound();
            }          
            return View(brand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Brand brand)
        {
            if (id != brand.id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _dB.UpdateBrand(brand);
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
            Brand brand = _dB.GetBrandById(id);

            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }
    }
}
