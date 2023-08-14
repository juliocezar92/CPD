using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CPD.Dominio.Entidades
{
    public class ProjetoDto
    {
        public int Id { get; set; }
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
    }
}
