using _4_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace _4_WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}