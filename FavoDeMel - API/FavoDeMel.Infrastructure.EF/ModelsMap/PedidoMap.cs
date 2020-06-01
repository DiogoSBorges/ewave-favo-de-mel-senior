using FavoDeMel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoDeMel.Infrastructure.EF.ModelsMap
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Data)
                .HasColumnName("Data");

            builder.Property(x => x.SituacaoId)
                .HasColumnName("SituacaoId");

            builder.Property(x => x.ComandaMovimentoId)
               .HasColumnName("ComandaMovimentoId");

            builder.HasOne(x => x.Situacao)
                .WithOne()
                .HasPrincipalKey<PedidoSituacao>(x => x.Id)
                .HasForeignKey<Pedido>(x => x.SituacaoId);   

            builder.HasOne(x => x.Movimento)
                .WithOne()
                .HasPrincipalKey<ComandaMovimento>(x => x.Id)
                .HasForeignKey<Pedido>(x => x.ComandaMovimentoId);    

            builder.HasMany(x=>x.Itens)
                .WithOne()
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.PedidoId);

        }
    }
}
