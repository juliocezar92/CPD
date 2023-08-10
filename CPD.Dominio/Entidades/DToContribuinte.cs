using CPD.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CPD.Dominio.Entidades
{
    public class DTOContribuinte
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public int? PessoaResponsavelId { get; set; }
        public int ProjetoId { get; set; }

        [Display(Name = "Valor Contribuição")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ValorContribuicao { get; set; }
        public Periodicidade Periodicidade { get; set; }

        [Display(Name = "Data Inicial")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataInicio { get; set; } =DateTime.Now;

        [Display(Name = "Data Final")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFim { get; set; } = DateTime.Now;
        public string NomePessoa { get; set; }
        public string NomeResponsavel { get; set; }
        public List<PessoaSimplesDto> ListaDePessoas { get; set; } = new List<PessoaSimplesDto>();
        public List<ProjetoDto> ListaDeProjetos { get; set; } = new List<ProjetoDto>();
        public List<PessoaSimplesDto> ListaDepessoasResponsavel { get; set; } = new List<PessoaSimplesDto>();
        public string NomeProjeto { get; set; }
    }

    public class PessoaSimplesDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class ProjetoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class CreatePessoaDto
    { 
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public int? PessoaResponsavelId { get; set; }
        public int ProjetoId { get; set; }

        [Display(Name = "Valor Contribuição")]
        
        public decimal ValorContribuicao { get; set; }
        public Periodicidade Periodicidade { get; set; }

        [Display(Name = "Data Inicial")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Data Final")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFim { get; set; }
        public List<PessoaSimplesDto> ListaDePessoas { get; set; } = new List<PessoaSimplesDto>();
        public List<ProjetoDto> ListaDeProjetos { get; set; } = new List<ProjetoDto>();
        public List<PessoaSimplesDto> ListaDepessoasResponsavel { get; set; } = new List<PessoaSimplesDto>();

    }
    public class ContribuicaoDto
    {
        public int Id { get; set; }
        [Display(Name = "Valor Liquido")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal ValorLiquido { get; set; }

        [Display(Name = "Data de Contribuição")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataContribuicao { get; set; }

        [Display(Name = "Tipo de Contribuição")]
        public TipoContribuicao TipoContribuicao { get; set; }

        [Display(Name = "Data Inicial")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataInicio { get; set; } = DateTime.Now;

        [Display(Name = "Data Final")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFim { get; set; } = System.DateTime.Now;
        public List<PessoaSimplesDto> ListaDePessoas { get; set; } = new List<PessoaSimplesDto>();
        public string PessoaNome { get; set; }
        public object PessoaId { get; set; }
        public decimal Valor { get; set; }
    }
}
