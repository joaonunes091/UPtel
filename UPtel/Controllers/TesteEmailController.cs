using UPtel.Services;
using UPtel.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPtel.Data;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UPtel.Controllers
{
    public class TesteEmailController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly UPtelContext bd;
        public TesteEmailController(IEmailSender emailSender, IWebHostEnvironment env, UPtelContext context)
        {
            _emailSender = emailSender;
            bd = context;
        }
        public IActionResult EnviaEmail()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult EnviaEmail(EmailModel email)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            TesteEnvioEmail(email.Destino, email.Assunto, email.Mensagem).GetAwaiter();
        //            return RedirectToAction("EmailEnviado");
        //        }
        //        catch (Exception)
        //        {
        //            return RedirectToAction("EmailFalhou");
        //        }
        //    }
        //    return View(email);
        //}

        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> TesteEnvioEmail()
        {
            List<Contratos> contratos = await bd.Contratos.ToListAsync();


            DateTime hoje = DateTime.Today;
            DateTime mespassado = hoje.AddMonths(-1);


            var dia1 = new DateTime(mespassado.Year, mespassado.Month, 1);
            DateTime finaldia = dia1.AddMonths(1).AddMinutes(-1);

            List<FaturaCliente> emailenviado = await bd.Faturas.Where(d => d.DataEmissao >= dia1 && d.DataEmissao <= finaldia).ToListAsync();


            foreach (var item in emailenviado)
            {
                if (item.DataEmissao.Month == mespassado.Month)
                {
                    return RedirectToAction("EmailsJaEnviados");
                }
            }


            string email; string assunto; string mensagem;
            var cliente = await bd.Users.Where(c => c.Tipo.Tipo.Contains("Cliente")).ToListAsync();



            foreach (var item in cliente)
            {
                if (item.ContratosCliente.Count() != 0)
                {
                    foreach (var fatura in contratos)
                    {

                        var valorpagar = await bd.Contratos.FirstOrDefaultAsync(c => c.ContratoId == fatura.ContratoId);
                        //var cliente = await bd.Users.FirstOrDefaultAsync(m => m.UserId == item.UserId);
                        decimal preco = valorpagar.PrecoContrato;
                        email = valorpagar.Cliente.Email;
                        int qq = (int)mespassado.Month;
                        var mes = await bd.Meses.SingleOrDefaultAsync(m => m.MesId == qq);
                        assunto = "UPtel - Faturação de " + mes.Mes;
                        mensagem = "Caro/a cliente, informamos que o preço a pagar em " + mes.Mes + " é de " + preco + " € da fatura de " + mes.Mes;

                        try
                        {
                            //email destino, assunto do email, mensagem a enviar
                            await _emailSender.SendEmailAsync(email, assunto, mensagem);


                        }
                        catch (Exception)
                        {
                            return RedirectToAction("EmailFalhou");
                        }


                        if (fatura.ClienteId == item.UsersId)
                        {
                            FaturaCliente faturaCliente = new FaturaCliente();

                            faturaCliente.DataEmissao = hoje;
                            faturaCliente.ContratoId = fatura.ContratoId;
                            faturaCliente.NomeCliente = fatura.Cliente.Nome;
                            faturaCliente.Morada = fatura.MoradaContrato;
                            faturaCliente.PrecoContrato = fatura.PrecoContrato;
                            faturaCliente.PacoteId = fatura.PacoteId;
                            faturaCliente.PrecoContrato = fatura.PrecoContrato;



                            if (ModelState.IsValid)
                            {
                                bd.Add(faturaCliente);
                                await bd.SaveChangesAsync();

                            }

                        }
                    }
                }
            }

            ////emailenviado.Add(new FaturaCliente() { DataEmissao = DateTime.Today, Enviado = true, mes = mes });
            //foreach (var item in emailenviado)
            //{
            //    bd.Faturas.Add(item);
            //}
            //await bd.SaveChangesAsync();
            return RedirectToAction("EmailEnviado");



        }
        public ActionResult EmailEnviado()
        {
            return View();
        }
        public ActionResult EmailsJaEnviados()
        {
            return View();
        }
        public ActionResult EmailFalhou()
        {
            return View();
        }

        //internal static string NomesDoMes(int mes)
        //{
        //    string NomedoMes = "";
        //    switch (mes)
        //    {
        //        case 1:
        //            NomedoMes = "Janeiro";
        //            break;
        //        case 2:
        //            NomedoMes = "Fevereiro";
        //            break;
        //        case 3:
        //            NomedoMes = "Março";
        //            break;
        //        case 4:
        //            NomedoMes = "Abril";
        //            break;
        //        case 5:
        //            NomedoMes = "Maio";
        //            break;
        //        case 6:
        //            NomedoMes = "Junho";
        //            break;
        //        case 7:
        //            NomedoMes = "Julho";
        //            break;
        //        case 8:
        //            NomedoMes = "Agosto";
        //            break;
        //        case 9:
        //            NomedoMes = "Setembro";
        //            break;
        //        case 10:
        //            NomedoMes = "Outubro";
        //            break;
        //        case 11:
        //            NomedoMes = "Novembro";
        //            break;
        //        case 12:
        //            NomedoMes = "Dezembro";
        //            break;

        //        default:
        //            break;
        //    }

        //    return NomedoMes;
        //}
    }
}
