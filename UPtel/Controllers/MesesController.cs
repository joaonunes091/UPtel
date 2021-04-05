using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UPtel.Data;
using UPtel.Models;

namespace UPtel.Controllers
{
    public class MesesController : Controller
    {
        private readonly UPtelContext _context;

        public MesesController(UPtelContext context)
        {
            _context = context;
        }

        // GET: Meses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Meses.ToListAsync());
        }

      

       
    }
}
