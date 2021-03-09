using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_3Tier.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryBLL _dB;
        public CategoryController(CategoryBLL db)
        {
            _dB = db;
        }
        public IActionResult Index()
        {
            var category = _dB.GetCategory().ToList();
            return Ok(category);
        }
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _dB.GetCategoryById(id);
        }
        [HttpPost]
        public IActionResult Create([Bind] Category category)
        {
            try
            {
                _dB.AddCategory(category);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Ok(category);
        }
        [HttpPost]
        public IActionResult Update([Bind] Category category)
        {
            try
            {

                if (category == null)
                {
                    return BadRequest();
                }
                else
                {
                    _dB.UpdateCategory(category);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (String.IsNullOrEmpty(category.name) )
            {
                return NotFound();
            }
            else
            {
                return Ok(category);
            }
        }
        [HttpPost("{id}")]
        public void Delete(int id)
        {
            _dB.DeleteCategory(id);
        }
    }
}
