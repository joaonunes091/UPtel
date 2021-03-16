using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class Reclamacao
    {
        public int ReclamacaoId { get; set; }

        public string Assunto { get; set; }

        public string Descriçao { get; set; }

        public int ClienteId { get; set; }

        public bool Resolvido { get; set; }
    }
}
