
using _1_Controle_Financeiro.Models;
using Microsoft.EntityFrameworkCore;
namespace _1_Controle_Financeiro.Database
{

    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Transacao>? Transacoes { get; set; }
        public DbSet<Financeiro>? Financas { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Categoria>().HasData(
                new Categoria { CategoriaId = "educação", Nome = "Educação" },
                new Categoria { CategoriaId = "salario", Nome = "Salario" },
                new Categoria { CategoriaId = "viagem", Nome = "Viagem" },
                new Categoria { CategoriaId = "Mercado", Nome = "mercado" },
                new Categoria { CategoriaId = "comissao", Nome = "Comissao" }

            );

            mb.Entity<Transacao>().HasData(
                new Transacao { TransacaoId = "ganho", Nome = "Ganho" },
                new Transacao { TransacaoId = "gasto", Nome = "Gasto" }
            );
            base.OnModelCreating(mb);
        }
    }
}
