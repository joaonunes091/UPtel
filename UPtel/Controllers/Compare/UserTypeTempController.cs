//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Uptel1.Data;
//using Uptel1.Models;

//namespace Uptel1.Controllers
//{
//    public class UserTypeTempController : Controller
//    {
//        private readonly UPtel1Context _context;

//        public UserTypeTempController(UPtel1Context context)
//        {
//            _context = context;
//        }

//        // GET: UserTypeTemp
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.UserType.ToListAsync());
//        }

//        // GET: UserTypeTemp/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var userType = await _context.UserType
//                .FirstOrDefaultAsync(m => m.TipoId == id);
//            if (userType == null)
//            {
//                return NotFound();
//            }

//            return View(userType);
//        }

//        // GET: UserTypeTemp/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: UserTypeTemp/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("TipoId,Tipo")] UserType userType)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(userType);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(userType);
//        }

//        // GET: UserTypeTemp/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var userType = await _context.UserType.FindAsync(id);
//            if (userType == null)
//            {
//                return NotFound();
//            }
//            return View(userType);
//        }

//        // POST: UserTypeTemp/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("TipoId,Tipo")] UserType userType)
//        {
//            if (id != userType.TipoId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(userType);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!UserTypeExists(userType.TipoId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(userType);
//        }

//        // GET: UserTypeTemp/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var userType = await _context.UserType
//                .FirstOrDefaultAsync(m => m.TipoId == id);
//            if (userType == null)
//            {
//                return NotFound();
//            }

//            return View(userType);
//        }

//        // POST: UserTypeTemp/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var userType = await _context.UserType.FindAsync(id);
//            _context.UserType.Remove(userType);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool UserTypeExists(int id)
//        {
//            return _context.UserType.Any(e => e.TipoId == id);
//        }
//    }
//}
