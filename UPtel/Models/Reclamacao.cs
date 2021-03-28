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
        [Key]
        public int ReclamacaoId { get; set; }

        public int UsersId { get; set; }

        [Required(ErrorMessage = "É necessário colocar um assunto")]
        [StringLength(25, ErrorMessage = "O limite de caracteres(25) foi ultrapassado")]
        public string Assunto { get; set; }

        [Required(ErrorMessage = "É necessário colocar uma descrição")]
        [StringLength(250, ErrorMessage = "O limite de caracteres(250) foi ultrapassado")]
        [Display(Name = "Descrição")]
        public string Descriçao { get; set; }

        [Display(Name = "Nome do cliente")]
        public string NomeCliente { get; set; }

        public bool ResolvidoOperador { get; set; }

        public bool ResolvidoCliente { get; set; }

        public ICollection<Reclamacao> ReclamacoesCliente { get; set; }

        [ForeignKey(nameof(Users.UsersId))]
        public virtual Users Cliente { get; set; }
    }
}
