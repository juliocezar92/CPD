using System.ComponentModel.DataAnnotations;

namespace CPD.Dtos
{
    public class ProjetoDto
    {
        public int Id { get; set; }
        [Display(Name = "Comunidade")]
        public int ComunidadeId { get; set; }
        public string NomeComunidade { get; set; }
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Display(Name = "Data Inicial")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataInicio { get; set; }
        [Display(Name = "Data Final")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFim { get; set; }
        [Display(Name = "Valor Estimado")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ValorEstimado { get; set; }
       
        [Display(Name = "Valor Arrecadado")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ValorArrecadado { get; set; }
        public List<ComunidadeDto> ListadeComunidades { get; set; } = new List<ComunidadeDto>();
    }
}
