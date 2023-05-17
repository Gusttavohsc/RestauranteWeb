using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteWeb.Domain.Entities;
using System;

namespace RestauranteWeb.Infra.Data.Maps
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cliente");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("NR_ID_CL")
                .UseMySqlIdentityColumn();

            builder.Property(x => x.Nome)
                .HasColumnName("TX_NOME_CL");

            builder.Property(x => x.Documento)
                .HasColumnName("TX_DOCUMENTO_CL");

            builder.HasMany(x => x.Pedidos)
                .WithOne(y => y.Cliente)
                .HasForeignKey(c => c.IdCliente);
        }
    }
}
