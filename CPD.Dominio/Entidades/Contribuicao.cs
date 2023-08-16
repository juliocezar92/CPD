using CPD.Dominio.Enum;
using System.ComponentModel.DataAnnotations;

namespace CPD.Dominio.Entidades
{
    public class Contribuicao
    {
        public int Id { get; set; }
        public int ContribuinteId { get; set; }
        public string NomeContribuinte { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Valor { get; set; }

        [Display(Name ="Valor Liquido")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ValorLiquido { get; set; }

        [Display(Name = "Data de Contribuição")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataContribuicao { get; set; }

        [Display(Name = "Tipo de Contribuição")]
        public TipoContribuicao TipoContribuicao { get; set; }

        public virtual Contribuinte Contribuinte { get; set; }
    }
}
