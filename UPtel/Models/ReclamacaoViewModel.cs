using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static System.ComponentModel.DataAnnotations.RegularExpressionAttribute;

namespace UPtel.Models
{
    public class ReclamacaoViewModel
    {
        public int Id { get; set; }

        public int ReclamacaoId { get; set; }

        public int ContratoId { get; set; }

        public string NomeCliente { get; set; }

        public string NomeFuncionario { get; set; }

        public string Assunto { get; set; }

        public string Descricao { get; set; }

        public bool ResolvidoOperador { get; set; }

        public bool ResolvidoCliente { get; set; }

        public bool PorResoponder { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime DataReclamacao { get; set; }

        public int FuncionarioId { get; set; }

        public string Mensagem { get; set; }

        public ICollection<Feedback> ListaMensagens { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime DataFeedback { get; set; }

        //public virtual ICollection<Feedback> Feedback { get; set; }
    }
}
