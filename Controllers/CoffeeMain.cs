using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using two.Models;
using MvcCoffee.Models;
using MvcOrder.Models;

namespace coffeeMain.Controllers
{
    public class CoffeeMainController: Controller
    {

        private readonly ApplicationDbContext _db;
        public CoffeeMainController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<Coffee> coffees = _db.coffees;
            return View(coffees); //menu 
        }


        public IActionResult Order()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Order(Order obj)
        {
            if (ModelState.IsValid)
            {
                _db.orders.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }
    }
}