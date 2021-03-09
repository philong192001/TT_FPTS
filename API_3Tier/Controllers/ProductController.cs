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
    public class ProductController : ControllerBase
    {
        private readonly ProductBLL _dB;
        public ProductController(ProductBLL db)
        {
            _dB = db;
        }
        public IActionResult Index()
        {
            var products = _dB.GetAllProduct().ToList();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _dB.GetProductById(id);
        }
        [HttpPost]
        public IActionResult Create([Bind] Product product)
        {
            try
            {
                _dB.AddProduct(product);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Ok(product);
        }
        [HttpPost]
        public IActionResult Update([Bind] Product product)
        {
            try
            {

                if (product == null)
                {
                    return BadRequest();
                }
                else
                {
                    _dB.UpdateProduct(product);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (String.IsNullOrEmpty(product.Name) && product.Price == null && product.Quantity == null && product.Id_brands == null && product.Id_categories == null && (product.Created_Date == null )) 
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }
        [HttpPost("{id}")]
        public void Delete(int id)
        {
            _dB.DeleteProduct(id);
        }
    }
}
