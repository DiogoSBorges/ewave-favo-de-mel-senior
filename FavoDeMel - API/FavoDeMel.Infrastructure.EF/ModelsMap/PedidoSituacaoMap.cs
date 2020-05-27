using FavoDeMel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoDeMel.Infrastructure.EF.ModelsMap
{
    public class PedidoSituacaoMap : IEntityTypeConfiguration<PedidoSituacao>
    {
        public void Configure(EntityTypeBuilder<PedidoSituacao> builder)
        {
            builder.ToTable("PedidoSituacao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.Nome)
                .HasColumnName("Nome");
        }
    }
}
