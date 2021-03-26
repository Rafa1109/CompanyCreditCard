using CompanyCreditCard.Domain.Models;
using CompanyCreditCard.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CompanyCreditCard.Infra.Data.Context
{
    public class CompanyCreditCardContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public CompanyCreditCardContext(DbContextOptions<CompanyCreditCardContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMapping());
            modelBuilder.ApplyConfiguration(new FaturaMapping());
            modelBuilder.ApplyConfiguration(new CompraMapping());
            modelBuilder.ApplyConfiguration(new ParcelaMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
