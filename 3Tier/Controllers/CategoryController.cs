using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace _3Tier.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryBLL _dB;
        public CategoryController(CategoryBLL db)
        {
            _dB = db;
        }
        public IActionResult Index()
        {
            var listCategory = _dB.GetCategory().ToList();
            return View(listCategory);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Category category)
        {
            if (ModelState.IsValid)
            {
                _dB.AddCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Category category = _dB.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Category category = _dB.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Category category)
        {
            if (id != category.id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _dB.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            return View(_dB);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Category category = _dB.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            _dB.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}
