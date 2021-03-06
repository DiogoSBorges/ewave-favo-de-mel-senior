﻿using FavoDeMel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoDeMel.Infrastructure.EF.ModelsMap
{
    public class PedidoItemProducaoMap : IEntityTypeConfiguration<PedidoItemProducao>
    {
        public void Configure(EntityTypeBuilder<PedidoItemProducao> builder)
        {
            builder.ToTable("PedidoItemProducao");

            builder.HasKey(x => x.PedidoItemId);

            builder.Property(x => x.PedidoItemId)
                .HasColumnName("PedidoItemId");

            builder.Property(x => x.DataInicio)
                .HasColumnName("DataInicio");

            builder.Property(x => x.DataFim)
                .HasColumnName("DataFim");

            builder.Property(x => x.PrioridadeId)
                .HasColumnName("PrioridadeId");

            builder.HasOne(x => x.Prioridade)
              .WithOne()
              .HasPrincipalKey<PedidoItemProducaoPrioridade>(x => x.Id)
              .HasForeignKey<PedidoItemProducao>(x => x.PrioridadeId);

            builder.HasOne(x => x.PedidoItem)
              .WithOne(x=>x.Producao)
              .HasPrincipalKey<PedidoItem>(x => x.Id)
              .HasForeignKey<PedidoItemProducao>(x => x.PedidoItemId).IsRequired(false);
            
        }
    }
}
