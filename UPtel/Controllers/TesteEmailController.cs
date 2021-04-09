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

        public async Task<IActionResult> TesteEnvioEmail()
        {
            var contratos = await bd.Contratos.ToListAsync();
            var emailenviado = await bd.EnvioDeFaturas.ToListAsync();

            DateTime hoje = DateTime.Today;
            DateTime mespassado = hoje.AddMonths(-1);
            int mes = mespassado.Month;

            foreach (var item in emailenviado)
            {
                if (item.mes == mes)
                {
                    return RedirectToAction("EmailsJaEnviados");
                }
            }


            string email; string assunto; string mensagem;


            foreach (var item in *)
            {
                //var cliente = await bd.Users.FirstOrDefaultAsync(m => m.UserId == item.UserId);
                decimal preco = *;
                email = cliente.Email;

                string NomeMes = NomesDoMes(mes);
                assunto = "UPtel - Faturação de "+ NomeMes;
                mensagem = "Caro/a cliente, informamos que o preço a pagar em " + NomeMes + "é de" + preco + "€ da fatura de ";

                try
                {
                    //email destino, assunto do email, mensagem a enviar
                    await _emailSender.SendEmailAsync(email, assunto, mensagem);


                }
                catch (Exception)
                {
                    return RedirectToAction("EmailFalhou");
                }
            }

            emailenviado.Add(new EnvioDeFaturas() { DataDeEnvio = DateTime.Today, Enviado = true, mes = mes });
            foreach (var item in emailenviado)
            {
                bd.EnvioDeFaturas.Add(item);
            }
            await bd.SaveChangesAsync();
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

        internal static string NomesDoMes(int mes)
        {
            string NomedoMes = "";
            switch (mes)
            {
                case 1:
                    NomedoMes = "Janeiro";
                    break;
                case 2:
                    NomedoMes = "Fevereiro";
                    break;
                case 3:
                    NomedoMes = "Março";
                    break;
                case 4:
                    NomedoMes = "Abril";
                    break;
                case 5:
                    NomedoMes = "Maio";
                    break;
                case 6:
                    NomedoMes = "Junho";
                    break;
                case 7:
                    NomedoMes = "Julho";
                    break;
                case 8:
                    NomedoMes = "Agosto";
                    break;
                case 9:
                    NomedoMes = "Setembro";
                    break;
                case 10:
                    NomedoMes = "Outubro";
                    break;
                case 11:
                    NomedoMes = "Novembro";
                    break;
                case 12:
                    NomedoMes = "Dezembro";
                    break;

                default:
                    break;
            }

            return NomedoMes;
        }
    }
}
