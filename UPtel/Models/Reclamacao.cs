using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class Reclamacao
    {
        public Reclamacao()
        {
            Feedback = new HashSet<Feedback>();
        }

        [Key]
        public int ReclamacaoId { get; set; }

        public int ContratoId { get; set; }

        public string NomeCliente { get; set; }

        public int FuncionarioId { get; set; }

        [Required(ErrorMessage = "É necessário colocar um assunto")]
        [StringLength(25, ErrorMessage = "O limite de caracteres(25) foi ultrapassado")]
        public string Assunto { get; set; }

        [Required(ErrorMessage = "É necessário colocar uma descrição")]
        [StringLength(250, ErrorMessage = "O limite de caracteres(250) foi ultrapassado")]
        [Display(Name = "Descrição")]
        public string Descriçao { get; set; }

        public bool ResolvidoOperador { get; set; }

        public bool ResolvidoCliente { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime DataReclamacao { get; set; }

        [ForeignKey(nameof(ContratoId))]
        [InverseProperty("Reclamacao")]
        public virtual Contratos Contratos { get; set; }

        [InverseProperty("Reclamacao")]
        public virtual ICollection<Feedback> Feedback { get; set; }

        [ForeignKey("FuncionarioId")]
        public Users Users { get; set; }
    }
}
