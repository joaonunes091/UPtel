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
//    public class UserTempController : Controller
//    {
//        private readonly UPtel1Context _context;

//        public UserTempController(UPtel1Context context)
//        {
//            _context = context;
//        }

//        // GET: UserTemp
//        public async Task<IActionResult> Index()
//        {
//            var uPtel1Context = _context.Users.Include(u => u.Tipo);
//            return View(await uPtel1Context.ToListAsync());
//        }

//        // GET: UserTemp/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var users = await _context.Users
//                .Include(u => u.Tipo)
//                .FirstOrDefaultAsync(m => m.UsersId == id);
//            if (users == null)
//            {
//                return NotFound();
//            }

//            return View(users);
//        }

//        // GET: UserTemp/Create
//        public IActionResult Create()
//        {
//            ViewData["TipoId"] = new SelectList(_context.UserType, "TipoId", "Tipo");
//            return View();
//        }

//        // POST: UserTemp/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("UsersId,Nome,Data,CartaoCidadao,Contribuinte,Morada,CodigoPostal,Telefone,Telemovel,Email,Iban,TipoId,CodigoPostalExt,Estado,Fotografia")] Users users)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(users);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["TipoId"] = new SelectList(_context.UserType, "TipoId", "Tipo", users.TipoId);
//            return View(users);
//        }

//        // GET: UserTemp/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var users = await _context.Users.FindAsync(id);
//            if (users == null)
//            {
//                return NotFound();
//            }
//            ViewData["TipoId"] = new SelectList(_context.UserType, "TipoId", "Tipo", users.TipoId);
//            return View(users);
//        }

//        // POST: UserTemp/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("UsersId,Nome,Data,CartaoCidadao,Contribuinte,Morada,CodigoPostal,Telefone,Telemovel,Email,Iban,TipoId,CodigoPostalExt,Estado,Fotografia")] Users users)
//        {
//            if (id != users.UsersId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(users);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!UsersExists(users.UsersId))
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
//            ViewData["TipoId"] = new SelectList(_context.UserType, "TipoId", "Tipo", users.TipoId);
//            return View(users);
//        }

//        // GET: UserTemp/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var users = await _context.Users
//                .Include(u => u.Tipo)
//                .FirstOrDefaultAsync(m => m.UsersId == id);
//            if (users == null)
//            {
//                return NotFound();
//            }

//            return View(users);
//        }

//        // POST: UserTemp/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var users = await _context.Users.FindAsync(id);
//            _context.Users.Remove(users);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool UsersExists(int id)
//        {
//            return _context.Users.Any(e => e.UsersId == id);
//        }
//    }
//}
