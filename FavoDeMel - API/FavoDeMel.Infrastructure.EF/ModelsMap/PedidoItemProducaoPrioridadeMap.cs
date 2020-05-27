using FavoDeMel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoDeMel.Infrastructure.EF.ModelsMap
{
    public class PedidoItemProducaoPrioridadeMap : IEntityTypeConfiguration<PedidoItemProducaoPrioridade>
    {
        public void Configure(EntityTypeBuilder<PedidoItemProducaoPrioridade> builder)
        {
            builder.ToTable("PedidoItemProducaoPrioridade");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.Nome)
                .HasColumnName("Nome");
        }
    }
}
