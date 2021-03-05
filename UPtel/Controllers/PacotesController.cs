using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UPtel.Data;
using UPtel.Models;

namespace UPtel.Controllers
{
    public class PacotesController : Controller
    {
        private readonly UPtelContext _context;

        public PacotesController(UPtelContext context)
        {
            _context = context;
        }

        // GET: Pacotes
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.Pacotes.Where(p => nomePesquisar == null || p.NomePacote.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };
            //var UPtelContext = _context.Pacotes.Include(p => p.NetIfixa).Include(p => p.NetMovel).Include(p => p.Telefone).Include(p => p.Telemovel).Include(p => p.Televisao);
            
            List<Pacotes> pacotes = await _context.Pacotes.Where(p => nomePesquisar == null || p.NomePacote.Contains(nomePesquisar))
                .Include(p => p.NetMovel)
                .Include(p => p.Telefone)
                .Include(p => p.Telemovel)
                .Include(p => p.Televisao)
                .Include(p => p.NetIfixa)
                .OrderBy(c => c.NomePacote)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Paginacao = paginacao,
                Pacotes = pacotes,
                NomePesquisar = nomePesquisar
            };

            return base.View(modelo);
        }
        

        // GET: Pacotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacotes = await _context.Pacotes
                .Include(p => p.NetIfixa)
                .Include(p => p.NetMovel)
                .Include(p => p.Telefone)
                .Include(p => p.Telemovel)
                .Include(p => p.Televisao)
                .FirstOrDefaultAsync(m => m.PacoteId == id);
            if (pacotes == null)
            {
                return NotFound();
            }

            return View(pacotes);
        }

        // GET: Pacotes/Create
        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            ViewData["NetIfixaId"] = new SelectList(_context.NetFixa, "NetFixaId", "Nome");
            ViewData["NetMovelId"] = new SelectList(_context.NetMovel, "NetMovelId", "Nome");
            ViewData["TelefoneId"] = new SelectList(_context.Telefone, "TelefoneId", "Nome");
            ViewData["TelemovelId"] = new SelectList(_context.Telemovel, "TelemovelId", "Nome");
            ViewData["TelevisaoId"] = new SelectList(_context.Televisao, "TelevisaoId", "Nome");
            return View();
        }

        // POST: Pacotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create([Bind("PacoteId,NomePacote,PrecoTotal,TelevisaoId,TelemovelId,NetIfixaId,TelefoneId,NetMovelId")] Pacotes pacotes)
        {

          
                decimal precoNetFixa, precoNetMovel, precoTelemovel, precoTelefone, precoTelevisao, total;

                var netFixa = _context.NetFixa.SingleOrDefault(n => n.NetFixaId == pacotes.NetIfixaId);
                var netMovel = _context.NetMovel.SingleOrDefault(n => n.NetMovelId == pacotes.NetMovelId);
                var telemovel = _context.Telemovel.SingleOrDefault(t => t.TelemovelId == pacotes.TelemovelId);
                var telefone = _context.Telefone.SingleOrDefault(t => t.TelefoneId == pacotes.TelefoneId);
                var televisao  = _context.Televisao.SingleOrDefault(t => t.TelevisaoId== pacotes.TelevisaoId);


                precoNetFixa = netFixa.PrecoNetFixa;
                precoNetMovel = netMovel.PrecoNetMovel;    
                precoTelemovel = telemovel.PrecoPacoteTelemovel;
                precoTelefone = telefone.PrecoPacoteTelefone;
                precoTelevisao = televisao.PrecoPacoteTelevisao;

                total = precoNetFixa + precoNetMovel + precoTelemovel + precoTelefone + precoTelevisao;
                pacotes.PrecoTotal = total;

                _context.Add(pacotes);
                await _context.SaveChangesAsync();
                ViewBag.Mensagem = "Pacote de serviços criado com sucesso";


            ViewData["NetIfixaId"] = new SelectList(_context.NetFixa, "NetFixaId", "Nome", pacotes.NetIfixaId);
            ViewData["NetMovelId"] = new SelectList(_context.NetMovel, "NetMovelId", "Nome", pacotes.NetMovelId);
            ViewData["TelefoneId"] = new SelectList(_context.Telefone, "TelefoneId", "Nome", pacotes.TelefoneId);
            ViewData["TelemovelId"] = new SelectList(_context.Telemovel, "TelemovelId", "Nome", pacotes.TelemovelId);
            ViewData["TelevisaoId"] = new SelectList(_context.Televisao, "TelevisaoId", "Nome", pacotes.TelevisaoId);
            return View("Sucesso");
            //return View(pacotes);
        }

        // GET: Pacotes/Edit/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacotes = await _context.Pacotes.FindAsync(id);
            if (pacotes == null)
            {
                return NotFound();
            }
            ViewData["NetIfixaId"] = new SelectList(_context.NetFixa, "NetFixaId", "Nome", pacotes.NetIfixaId);
            ViewData["NetMovelId"] = new SelectList(_context.NetMovel, "NetMovelId", "Nome", pacotes.NetMovelId);
            ViewData["TelefoneId"] = new SelectList(_context.Telefone, "TelefoneId", "Nome", pacotes.TelefoneId);
            ViewData["TelemovelId"] = new SelectList(_context.Telemovel, "TelemovelId", "Nome", pacotes.TelemovelId);
            ViewData["TelevisaoId"] = new SelectList(_context.Televisao, "TelevisaoId", "Nome", pacotes.TelevisaoId);
            return View(pacotes);
        }

        // POST: Pacotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int id, [Bind("PacoteId,NomePacote,PrecoTotal,TelevisaoId,TelemovelId,NetIfixaId,TelefoneId,NetMovelId")] Pacotes pacotes)
        {
            if (id != pacotes.PacoteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacotes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacotesExists(pacotes.PacoteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Mensagem = "Pacote de serviços alterado com sucesso";
                return View("Sucesso");
            }
            ViewData["NetIfixaId"] = new SelectList(_context.NetFixa, "NetFixaId", "Nome", pacotes.NetIfixaId);
            ViewData["NetMovelId"] = new SelectList(_context.NetMovel, "NetMovelId", "Nome", pacotes.NetMovelId);
            ViewData["TelefoneId"] = new SelectList(_context.Telefone, "TelefoneId", "Nome", pacotes.TelefoneId);
            ViewData["TelemovelId"] = new SelectList(_context.Telemovel, "TelemovelId", "Nome", pacotes.TelemovelId);
            ViewData["TelevisaoId"] = new SelectList(_context.Televisao, "TelevisaoId", "Nome", pacotes.TelevisaoId);
            return View(pacotes);
        }

        // GET: Pacotes/Delete/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacotes = await _context.Pacotes
                .Include(p => p.NetIfixa)
                .Include(p => p.NetMovel)
                .Include(p => p.Telefone)
                .Include(p => p.Telemovel)
                .Include(p => p.Televisao)
                .FirstOrDefaultAsync(m => m.PacoteId == id);
            if (pacotes == null)
            {
                return NotFound();
            }

            return View(pacotes);
        }

        // POST: Pacotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pacotes = await _context.Pacotes.FindAsync(id);
            _context.Pacotes.Remove(pacotes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacotesExists(int id)
        {
            return _context.Pacotes.Any(e => e.PacoteId == id);
        }
    }
}
