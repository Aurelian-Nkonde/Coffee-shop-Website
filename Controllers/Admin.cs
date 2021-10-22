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

namespace admin.Controllers
{
    public class AdminController: Controller
    {

        //confgure dependency injection
        private readonly ApplicationDbContext _db;
        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
        
            return View();
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Coffee obj)
        {
            if (ModelState.IsValid)
            {
                _db.coffees.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj); 
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var data = _db.coffees.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return View(data);
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Coffee obj)
        {
            if (ModelState.IsValid)
            {
                _db.coffees.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj); 
        }



        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var data = _db.coffees.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return View(data);
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? id)
        {
            var dataToDelete = _db.coffees.Find(id);
            if (dataToDelete == null)
            {
                return RedirectToAction("cant");
            }
            else
            {
                _db.coffees.Remove(dataToDelete);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        public IActionResult CoffeeDetails()
        {
            IEnumerable<Coffee> listCoffess = _db.coffees;
            return View(listCoffess);
        }

        public IActionResult OrderDetails()
        {
            IEnumerable<Order> orders = _db.orders;
            return View(orders);
        }



        public IActionResult DeleteOrder(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var orderDel = _db.orders.Find(id);
            if (orderDel == null)
            {
                return NotFound();
            }
            else
            {
                return View(orderDel);
            }

        }


        public IActionResult DeleteOrderFinal(int? id)
        {
            var deleteid = _db.orders.Find(id);
            if (deleteid == null)
            {
                return RedirectToAction("cant");
            }
            else
            {
                _db.orders.Remove(deleteid);
                _db.SaveChanges();
                return RedirectToAction("OrderDetails");
            }
        }

        public IActionResult ViewOrder(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var orderdetail = _db.orders.Find(id);
            if (orderdetail == null)
            {
                return NotFound();
            }
            else
            {
                return View(orderdetail);
            }
        }
    }
}