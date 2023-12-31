﻿using CPD.Dominio.Enum;
using System.ComponentModel.DataAnnotations;

namespace CPD.Dtos
{
    public class PessoaDto
    {
        public int Id { get; set; }
        [Display (Name ="Comunidade")]
        public int ComunidadeId { get; set; }
        public string NomeComunidade { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        [Display(Name = "Tipo de Pessoa")]
        public TipoPessoa TipoPessoa { get; set; }
        public List<ComunidadeDto> ListadeComunidades { get; set; } = new List<ComunidadeDto>();
    }
}
