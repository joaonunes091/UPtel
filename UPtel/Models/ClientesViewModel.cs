using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class ClientesViewModel
    {
        public int Id { get; set; }

        //Dados Pessoais
        [Display(Name = "Nome")]
        public string NomeCliente { get; set; }

        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Número do cartão de cidadão")]
        public string CartaoCidadao { get; set; }

        [Display(Name = "Número de contribuinte")]
        public string NumeroContribuinte { get; set; }

        public string Morada { get; set; }

        [Display(Name = "Código postal")]
        public string CodiogoPostal { get; set; }

        public string ExtensaoCodigoPostal { get; set; }
        public int? Posicao { get; set; }

        public string Telefone { get; set; }

        [Display(Name = "Telemóvel")]
        public string Telemovel { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public byte[] Fotografia { get; set; }

        //Informação Contrato

        [Display(Name = "Nome do funcionário")]
        public string NomeFuncionario { get; set; }

        [Display(Name = "Data de início")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Fidelização")]
        public int? Fidelizacao { get; set; }

        [Display(Name = "Tempo de promoção")]
        public int? TempoPromocao { get; set; }
        
        [Column(TypeName = "decimal(5, 2)")]
        [Display(Name = "Preço do contrato")]
        public decimal PrecoContrato { get; set; }

        [Display(Name = "Números associados")]
        public string NumerosAssociados { get; set; }

        public List<Contratos> ListaContratos { get; set; }

        //Informacao Pacote

        [Display(Name = "Nome do pacote")]
        public string NomePacote { get; set; }

        [Display(Name = "Net fixa")]
        public string NetFixaPacote { get; set; }

        [Display(Name = "Net móvel")]
        public string NetMovelPacote { get; set; }

        [Display(Name = "Telemóvel")]
        public string TelemovelPacote { get; set; }

        //Novas funcionalidades
        [DataType(DataType.Date)]
        public DateTime DataRegisto { get; set; }

        [Display(Name = "Distrito")]
        public virtual Distrito DistritoNome { get; set; }
        //

        public string TelefonePacote { get; set; }

        [Display(Name = "Televisão")]
        public string TelevisaoPacote { get; set; }
       
        [Column(TypeName = "decimal(5, 2)")]
        [Display(Name = "Preço do pacote")]
        public decimal PrecoPacote { get; set; }

        //Informação Promoções

        [Display(Name = "Nome da promoção")]
        public string NomePromocao { get; set; }

        [Display(Name = "Descrição da promoção")]
        public string DescricaoPromocao { get; set; }

        public int PromocaoCanais { get; set; }

        public int Desconto { get; set; }
    }
}
