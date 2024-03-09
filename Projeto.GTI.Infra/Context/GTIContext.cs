using Microsoft.EntityFrameworkCore;
using Projeto.GTI.Domain.Entities;
using Projeto.GTI.Infra.Configuration;

namespace Projeto.GTI.Infra.Context
{

    public class GTIContext : DbContext
    {


        public GTIContext(DbContextOptions<GTIContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Cliente { get; set; }
           public DbSet<EnderecoCliente> EnderecoCliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new EnderecoClienteConfig());
            base.OnModelCreating(modelBuilder);
        }

        // Comandos Code first
        // Add-Migration  NomeMigration
        // Update-DataBase
        // Remove-Migration


    }
}
