using FavoDeMel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoDeMel.Infrastructure.EF.ModelsMap
{
    public class PedidoItemSituacaoMap : IEntityTypeConfiguration<PedidoItemSituacao>
    {
        public void Configure(EntityTypeBuilder<PedidoItemSituacao> builder)
        {
            builder.ToTable("PedidoItemSituacao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.Nome)
                .HasColumnName("Nome");
        }
    }
}
