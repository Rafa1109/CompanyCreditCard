using CompanyCreditCard.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyCreditCard.Infra.Data.Mappings
{
    public class CompraMapping : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {
            builder.ToTable("TB_CC_COMPRA");
            builder.HasKey(x => x.CodCompra);

            builder.HasOne(c => c.Cliente)
                .WithMany(x => x.Compras)
                .HasForeignKey(x => x.CodCliente)
                .IsRequired();

            builder.Property(c => c.ValorCompra)
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.DescrExtrato)
                .HasColumnType("varchar(50)");
        }
    }
}
