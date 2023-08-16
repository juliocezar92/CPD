
using CPD.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CPD.Dominio.Entidades
{
    public class Contribuinte
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        [Display(Name = "Valor de Contribuição")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal ValorContribuicao { get; set; }

        public Periodicidade Periodicidade { get; set; }

        [Display(Name = "Data Inicial")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataInicio { get; set; } = DateTime.Now;

        [Display(Name = "Data Final")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFim { get; set; } = new DateTime();
        public int? PessoaResponsavelId { get; set; }
        [Display(Name = "Pessoa Responsavel")]
        public virtual Pessoa PessoaResponsavel { get; set; }
        public int ProjetoId { get; set; }

        public virtual Projeto Projeto { get; set; }
     
    }
}
