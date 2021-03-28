using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }

        [ForeignKey(nameof(Reclamacao.ReclamacaoId))]
        public int ReclamacaoId { get; set; }

        [ForeignKey(nameof(Users.UsersId))]
        public int FuncionarioId { get; set; }

        [ForeignKey(nameof(Users.UsersId))]
        public int ClienteId { get; set; }

        public string FeedbackCliente { get; set; }

        public string RespostaFuncionario { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

    }
}
