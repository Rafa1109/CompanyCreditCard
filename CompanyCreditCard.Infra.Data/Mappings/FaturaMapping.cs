using CompanyCreditCard.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyCreditCard.Infra.Data.Mappings
{
    public class FaturaMapping : IEntityTypeConfiguration<Fatura>
    {
        public void Configure(EntityTypeBuilder<Fatura> builder)
        {
            builder.ToTable("TB_CC_FATURA");
            builder.HasKey(c => c.CodFatura);

            builder.HasOne(c => c.Cliente)
                .WithMany(x => x.Faturas)
                .HasForeignKey(x => x.CodCliente)
                .IsRequired();

            builder.Property(c => c.ValorFatura)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(c => c.CodigoBarra)
                .HasColumnType("varchar(47)");
        }
    }
}
