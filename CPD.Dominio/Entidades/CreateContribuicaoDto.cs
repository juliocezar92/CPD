using CPD.Dominio.Enum;
using System.ComponentModel.DataAnnotations;

namespace CPD.Dominio.Entidades
{
    public class CreateContribuicaoDto
    {
        public string NomeContribuinte { get; set; }
        public int ContribuinteId { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }

        [Display(Name = "Valor Liquido")]
        [DisplayFormat(DataFormatString = "{0:N}")]
        public decimal ValorLiquido { get; set; }

        [Display(Name = "Data de Contribuição")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataContribuicao { get; set; } = DateTime.Now;

        [Display(Name = "Tipo de Contribuição")]
        public TipoContribuicao TipoContribuicao { get; set; }


    }
}
