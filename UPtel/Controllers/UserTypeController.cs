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
    public class UserTypeController : Controller
    {
        private readonly UPtelContext _context;

        public UserTypeController(UPtelContext context)
        {
            _context = context;
        }

        // GET: TipoClientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserType.ToListAsync());
        }

        // GET: TipoClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userType = await _context.UserType
                .FirstOrDefaultAsync(m => m.TipoId == id);
            if (userType == null)
            {
                return NotFound();
            }

            return View(userType);
        }

        // GET: TipoClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoId,Tipo")] UserType userType)
        {
            if (!ModelState.IsValid)
            {
                return View(userType);
            }
            
            _context.Add(userType);
            await _context.SaveChangesAsync();
            ViewBag.Mensagem = "Tipo de Cliente adicionado com sucesso";
            return View("Sucesso");
            //return RedirectToAction(nameof(Index));
        }

        // GET: TipoClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userType = await _context.UserType.FindAsync(id);
            if (userType == null)
            {
                ViewBag.Mensagem = "Ocorreu um erro, possivelmente o tipo de cliente já foi eliminado.";
                return View("Erro");
            }
            return View(userType);
        }

        // POST: TipoClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoId,Tipo")] UserType userType)
        {
            if (id != userType.TipoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTypeExists(userType.TipoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Mensagem = "Tipo de cliente alterado com sucesso";
                return View("Sucesso");
            }
            return View(userType);
        }

        // GET: TipoClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userType = await _context.UserType
                .FirstOrDefaultAsync(m => m.TipoId == id);
            if (userType == null)
            {
                ViewBag.Mensagem = "O tipo de cliente já foi eliminado por outra pessoa.";
                return View("Sucesso");
            }

            return View(userType);
        }

        // POST: TipoClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userType = await _context.UserType.FindAsync(id);
            _context.UserType.Remove(userType);
            await _context.SaveChangesAsync();
            ViewBag.Mensagem = "O tipo de cliente foi eliminado com sucesso.";
            return View("Sucesso");
        }

        private bool UserTypeExists(int id)
        {
            return _context.UserType.Any(e => e.TipoId == id);
        }
    }
}
