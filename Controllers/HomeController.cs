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
    public class HomeController : Controller
    {
        private ModelsContext _context;
        public HomeController(ModelsContext context) {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult dashboard(){
            ViewBag.products = _context.products.OrderByDescending(p => p.created_at).Take(5).ToList();
            ViewBag.customers = _context.customers.OrderByDescending(c => c.created_at).Take(3).ToList();
            ViewBag.orders = _context.orders.Include(o => o.product).Include(o => o.customer).OrderByDescending(o => o.created_at).Take(3).ToList();
            return View("index");
        }

        [HttpGet("orders")]
        public IActionResult orders() {
            ViewBag.customers = _context.customers.ToList();
            ViewBag.products = _context.products.ToList();
            ViewBag.orders = _context.orders.Include(o => o.customer).Include(o => o.product).ToList();
            ViewBag.orderError = TempData["orderError"];
            return View("orders");
        }

        [HttpPost("orders/add")]
        public IActionResult createOrder(Order o) {
            Product prod = _context.products.SingleOrDefault(p => p.id == o.product_id);

            if(o.quantity <= prod.quantity) {
                prod.quantity -= o.quantity;
                _context.orders.Add(o);
                _context.SaveChanges();
            } else {
                TempData["orderError"] = $"Oh no! There aren't enough {prod.name}(s) in stock!";
            }
            return RedirectToAction("orders");
        }

        [HttpGet("customers")]
        public IActionResult customers() {
            ViewBag.customers = _context.customers.ToList();
            return View("customers");
        }

        [HttpPost("customers/add")]
        public IActionResult createCustomer(Customer c) {
            _context.customers.Add(c);
            _context.SaveChanges();
            return RedirectToAction("customers");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
