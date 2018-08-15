using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class ProductController : Controller
    {
        private ModelsContext _context;
        public ProductController(ModelsContext context) {
            _context = context;
        }

        [HttpGet("products")]
        public IActionResult products() {
            List<Product> productList = _context.products.ToList();
            ViewBag.products = productList;
            return View("products");
        }

        [HttpPost("product/add")]
        public IActionResult createProduct(Product p) {
            _context.products.Add(p);
            _context.SaveChanges();
            return RedirectToAction("products");
        }
    }
}