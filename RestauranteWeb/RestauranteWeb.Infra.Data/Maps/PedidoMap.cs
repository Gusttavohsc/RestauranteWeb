using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteWeb.Domain.Entities;

namespace RestauranteWeb.Infra.Data.Maps
{
	public class PedidoMap : IEntityTypeConfiguration<Pedido>
	{
		public void Configure(EntityTypeBuilder<Pedido> builder)
		{

			builder.ToTable("pedido");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
					.HasColumnName("NR_ID_PE")
					.UseMySqlIdentityColumn();

			builder.Property(x => x.IdCliente)
					.HasColumnName("NR_CLIENTE_ID_PE");

			builder.Property(x => x.IdPrato)
					.HasColumnName("NR_PRATO_ID_PE");

			builder.Property(x => x.Mesa)
					.HasColumnName("NR_MESA_PE");

			builder.Property(x => x.Valor)
					.HasColumnName("NR_VALOR_PE");

			builder.Property(x => x.Status)
					.HasColumnName("TX_STATUS_PE");

			builder.HasOne(x => x.Cliente)
		.WithMany(x => x.Pedidos);

			builder.HasOne(x => x.Prato)
					.WithMany(x => x.Pedidos);
		}
	}
}
