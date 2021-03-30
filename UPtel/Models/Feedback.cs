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

        
        public int ReclamacaoId { get; set; }


        public int FuncionarioId { get; set; }

        public string Mensagem { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime DataFeedback { get; set; }

        [ForeignKey(nameof(ReclamacaoId))]
        [InverseProperty("Feedback")]
        public virtual Reclamacao Reclamacao { get; set; }

        [ForeignKey("FuncionarioId")]
        public Users Users { get; set; }
    }
}
