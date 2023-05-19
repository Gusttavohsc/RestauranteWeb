using Microsoft.EntityFrameworkCore;
using RestauranteWeb.Domain.Entities;

namespace RestauranteWeb.Infra.Data.Maps
{
	public class PratoMap : IEntityTypeConfiguration<Prato>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Prato> builder)
		{
			builder.ToTable("prato");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
					.HasColumnName("NR_ID_PR")
					.UseMySqlIdentityColumn();

			builder.Property(x => x.Nome)
					.HasColumnName("TX_NOME_PR");

			builder.Property(x => x.Categoria)
					.HasColumnName("TX_CATEGORIA_PR");

			builder.Property(x => x.Preparo)
					.HasColumnName("TX_PREPARO_PR");

			builder.Property(x => x.Valor)
					.HasColumnName("NR_VALOR_PR");

			builder.Property(x => x.Descricao)
					.HasColumnName("TX_DESCRICAO_PR");

			builder.Property(x => x.Status)
					.HasColumnName("ST_STATUS_PR");

			builder.HasMany(x => x.Pedidos)
					.WithOne(y => y.Prato)
					.HasForeignKey(y => y.IdPrato);
		}
	}
}
