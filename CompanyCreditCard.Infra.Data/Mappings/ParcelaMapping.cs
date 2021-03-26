using CompanyCreditCard.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyCreditCard.Infra.Data.Mappings
{
    public class ParcelaMapping : IEntityTypeConfiguration<Parcela>
    {
        public void Configure(EntityTypeBuilder<Parcela> builder)
        {
            builder.ToTable("TB_CC_PARCELA");
            builder.HasKey(x => x.CodParcela);

            builder.HasOne(x => x.Compra)
                .WithMany(x => x.Parcelas)
                .HasForeignKey(x => x.CodCompra)
                .IsRequired();

            builder.Property(c => c.ValorParcela)
                .HasColumnType("decimal(18,2)");


            builder.HasOne(x => x.Fatura)
                .WithMany(x => x.Parcelas)
                .HasForeignKey(x => x.CodFatura)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

        }
    }
}
