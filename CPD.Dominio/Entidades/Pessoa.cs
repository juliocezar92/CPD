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
    public class Pessoa
    {
        public int Id { get; set; }
        public int ComunidadeId { get; set; }
        public virtual Comunidade Comunidade { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        [Display(Name = "Tipo de Pessoa")]
        public TipoPessoa TipoPessoa { get; set; }
    }
}
