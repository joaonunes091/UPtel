using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Controllers
{
    public class Team : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
