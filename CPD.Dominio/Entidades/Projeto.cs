using System.ComponentModel.DataAnnotations;


namespace CPD.Dominio.Entidades
{
    public class Projeto
    {
        public int Id { get; set; }
        public int ComunidadeId { get; set; }
        public virtual Comunidade Comunidade { get; set; }
        [Display(Name ="Nome")]
        public string Name { get; set; }
        [Display(Name = "Data Inicial")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataInicio { get; set; }
        [Display(Name="Data Final")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFim { get; set; }
        [Display(Name = "Valor Arrecadado")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ValorEstimado { get; set; }


    }
}
