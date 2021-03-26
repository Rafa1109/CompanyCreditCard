using CompanyCreditCard.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyCreditCard.Infra.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("TB_CC_CLIENTE");
            builder.HasKey(x => x.Cod_Cliente);

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(60)");

            builder.Property(c => c.Endereco)
                .HasColumnType("varchar(60)");

            builder.Property(c => c.Cep)
                .HasColumnType("varchar(8)");

            builder.Property(c => c.Municipio)
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Uf)
                .HasColumnType("varchar(2)");

            builder.Property(c => c.Login)
                .HasColumnType("varchar(30)");

            builder.Property(c => c.Senha)
                .HasColumnType("varchar(60)");

            builder.Property(c => c.Email)
                .HasColumnType("varchar(80)");
        }
    }
}
