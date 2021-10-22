using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using two.Models;

namespace contact.Controllers
{
    public class ContactController: Controller
    {
        // action methods
        public IActionResult Index()
        {
            return View();
        }
    }
}