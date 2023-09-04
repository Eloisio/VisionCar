using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using visioncar.Models;

namespace visioncar.Context
{
    public class visioncarContext : DbContext
    {
        public visioncarContext(DbContextOptions<visioncarContext> options) : base(options) { }
        public DbSet<visioncar.Models.Product> Product { get; set; }
        public DbSet<visioncar.Models.EmpresaModel> Empresa { get; set; }
        public DbSet<visioncar.Models.UserModel> Users { get; set; }
        public DbSet<visioncar.Models.ClienteModel> Cliente { get; set; }
        public DbSet<visioncar.Models.ProdutoModel> Produto { get; set; }
        public DbSet<visioncar.Models.ServicoModel> Servico { get; set; }
        public DbSet<visioncar.Models.VendaModel> Venda { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
