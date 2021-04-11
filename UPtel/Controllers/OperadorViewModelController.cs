using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UPtel.Data;
using UPtel.Models;

namespace UPtel.Controllers
{
    [Authorize(Roles = "Operador")]
    public class OperadorViewModelController : Controller
    {
        private readonly UPtelContext _context;
        private readonly UserManager<IdentityUser> _gestorUtilizadores;


        public OperadorViewModelController(UPtelContext context, UserManager<IdentityUser> gestorUtilizadores)
        {
            _context = context;
            _gestorUtilizadores = gestorUtilizadores;
        }

        // GET: OperadorViewModel
        public async Task<IActionResult> Index(int? id, OperadorViewModel operador)
        {
            

            List<Users> melhoresOperadores = await _context.Users.Where(p => p.Tipo.Tipo.Contains("Operador"))
                .Include(d=>d.DistritoNome)
               .OrderByDescending(c => c.PrecoContratosFunc)
               .ToListAsync();

            int x = 0;

            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Users = melhoresOperadores,
            };

            foreach (var item in modelo.Users)
            {
                x++;
                item.Posicao = x;
            }


            var userEmail = _gestorUtilizadores.GetUserName(HttpContext.User);
            Users infoOperador = await _context.Users.SingleOrDefaultAsync(x => x.Email == userEmail);
            FaturacaoOperador op = await _context.FaturacaoOperadors.SingleOrDefaultAsync(x => x.FuncinarioId == infoOperador.UsersId);



            operador = new OperadorViewModel
            {
                Id = infoOperador.UsersId,
                NomeOperador = infoOperador.Nome,
                DataNascimento = infoOperador.Data,
                CartaoCidadao = infoOperador.CartaoCidadao,
                NumeroContribuinte = infoOperador.Contribuinte,
                Morada = infoOperador.Morada,
                CodiogoPostal = infoOperador.CodigoPostal,
                ExtensaoCodigoPostal = infoOperador.CodigoPostalExt,
                Telefone = infoOperador.Telefone,
                Telemovel = infoOperador.Telemovel,
                Email = infoOperador.Email,
                DataRegisto = infoOperador.DataRegisto,
                DistritoNome = infoOperador.DistritoNome,
                PrecoContratosFunc = infoOperador.PrecoContratosFunc,
                Posicao = infoOperador.Posicao,
                ValorMensalFat = op.ValorMensalFat,
                Fotografia = infoOperador.Fotografia,
                
            };

            return View(operador);
        }
        
    }
}
