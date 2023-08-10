using VisionCar.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace VisionCar.Infrastructure.Persistence
{
    public class VisionCarDbContext : DbContext
    {
        public VisionCarDbContext(DbContextOptions<VisionCarDbContext> options) : base(options)
        {
            
        }

        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Servico> Servico { get; set; }
        public DbSet<Venda> Venda { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
