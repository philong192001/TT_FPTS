using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace _3_Tier.Controllers
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
    }
}
