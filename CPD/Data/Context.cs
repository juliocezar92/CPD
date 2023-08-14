using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CPD.Dominio.Entidades;
using System.Globalization;

namespace CPD.Data
{
    public class Context : DbContext
    {

        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }
        public DbSet<Pessoa> Pessoa { get; set; } = default!;

        public DbSet<Contribuinte> Contribuinte { get; set; } = default!;

        public DbSet<Contribuicao> Contribuicao { get; set; } = default!;

        public DbSet<Projeto> Projeto { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da relação para a propriedade Pessoa
            modelBuilder.Entity<Contribuinte>()
                .HasOne(c => c.Pessoa)
                .WithMany()
                .HasForeignKey(c => c.PessoaId)
                .OnDelete(DeleteBehavior.Restrict); 

            // Configuração da relação para a propriedade PessoaResponsavel
            modelBuilder.Entity<Contribuinte>()
                .HasOne(c => c.PessoaResponsavel)
                .WithMany()
                .HasForeignKey(c => c.PessoaResponsavelId)
                .OnDelete(DeleteBehavior.Restrict);

            //Configuração da relação para propriedade Projeto
            modelBuilder.Entity<Contribuinte>()
               .HasOne(c => c.Projeto)
               .WithMany()
               .HasForeignKey(c => c.ProjetoId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contribuicao>().HasOne(x => x.Contribuinte)
                .WithMany()
                .HasForeignKey(x => x.ContribuinteId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CPD.Dominio.Entidades.Comunidade> Comunidade { get; set; } = default!;
    }
}
