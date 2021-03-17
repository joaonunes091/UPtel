using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class Reclamacao
    {
        public int ReclamacaoId { get; set; }

        public int UsersId { get; set; }

        public string Assunto { get; set; }

        public string Descriçao { get; set; }

        public string NomeCliente { get; set; }

        public bool Resolvido { get; set; }

        [ForeignKey(nameof(Users.UsersId))]
        public virtual Users Cliente { get; set; }
    }
}
