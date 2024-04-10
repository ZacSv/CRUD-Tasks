using Microsoft.EntityFrameworkCore;
using TaskSystem.Models;
namespace TaskSystem.Data
{
    public class SistemaTarefasDBContex : DbContext
    {
        public SistemaTarefasDBContex(DbContextOptions<SistemaTarefasDBContex> options)
            :base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios {  get; set; }
        public DbSet<TarefasModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
