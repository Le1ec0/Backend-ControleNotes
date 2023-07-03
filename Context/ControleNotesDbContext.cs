using Microsoft.EntityFrameworkCore;
using ControleNotes.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ControleNotes.Context
{
    public class ControleNotesDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Notebook> Notebooks { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configurar a string de conexão com o banco de dados
            optionsBuilder.UseSqlServer("your_connection_string");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar mapeamento das entidades (chaves primárias, chaves estrangeiras, etc.)
            // Aqui você pode usar fluent API ou atributos para mapear as entidades.
            // Exemplo:
            modelBuilder.Entity<Emprestimo>()
                .HasKey(e => e.CodEmprestimo);

            modelBuilder.Entity<Emprestimo>()
                .HasOne(e => e.Notebook)
                .WithMany()
                .HasForeignKey(e => e.CodNotebook);

            modelBuilder.Entity<Emprestimo>()
                .HasOne(e => e.Comodatario)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioComodatario);

            modelBuilder.Entity<Emprestimo>()
                .HasOne(e => e.Comodante)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioComodante);

            // Repita o processo de configuração para as outras entidades

            base.OnModelCreating(modelBuilder);
        }
    }
}