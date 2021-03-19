using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_3Tier.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly BrandBLL _dB;
        public BrandController(BrandBLL db)
        {
            _dB = db;
        }
        
        public IActionResult GetAllBrand()
        {
          var brands =  _dB.GetBrand().ToList();
            return Ok(brands);
        }
        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            return _dB.GetBrandById(id);
        }
        [HttpPost]
        //[EnableCors("AllowAll")]
        public IActionResult Create([Bind] Brand brand)
        {
            try
            {
                _dB.AddBrand(brand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Ok(brand);
        }
        [HttpPost]
        public IActionResult Update([Bind] Brand brand)
        {                                                   
                try
                {

                    if (brand == null)
                    {
                        return BadRequest();
                    }
                    else
                    {
                        _dB.UpdateBrand(brand);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            if(String.IsNullOrEmpty( brand.name))
            {
                return NotFound();
            }
            else
            {
                return Ok(brand);
            }
        }
        [HttpPost("{id}")]
        public void Delete(int id)
        {
            _dB.DeleteBrand(id);
        }
    }
}
