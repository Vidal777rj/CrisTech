
using Microsoft.EntityFrameworkCore;
namespace _1_Controle_Financeiro.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}