using FavoDeMel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

namespace FavoDeMel.Infrastructure.EF.ModelsMap
{
    public class PedidoItemMap : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidoItem");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Observacao)
                .HasColumnName("Observacao");

            builder.Property(x => x.ProdutoId)
                .HasColumnName("ProdutoId");

            builder.Property(x => x.PedidoId)
                .HasColumnName("PedidoId");

            builder.Property(x => x.SituacaoId)
                .HasColumnName("SituacaoId");

            builder.HasOne(x => x.Produto)
                .WithOne()
                .HasPrincipalKey<Produto>(x => x.Id)
                .HasForeignKey<PedidoItem>(x => x.ProdutoId);            

            builder.HasOne(x => x.Situacao)
               .WithOne()
               .HasPrincipalKey<PedidoItemSituacao>(x => x.Id)
               .HasForeignKey<PedidoItem>(x => x.SituacaoId);

            builder.HasOne(x => x.Pedido)
               .WithMany(x => x.Itens)
               .HasPrincipalKey(x => x.Id)
               .HasForeignKey(x => x.PedidoId);
        }
    }
}
