using FavoDeMel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoDeMel.Infrastructure.EF.ModelsMap
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .HasColumnName("Nome");

            builder.Property(x => x.Descricao)
                .HasColumnName("Descricao");

            builder.Property(x => x.TempoPreparo)
                .HasColumnName("TempoPreparo");

            builder.Property(x => x.Valor)
                .HasColumnName("Valor");

            builder.Property(x => x.TipoId)
                .HasColumnName("TipoId");

            builder.HasOne(x => x.Tipo)
                .WithOne()
                .HasPrincipalKey<ProdutoTipo>(x => x.Id)
                .HasForeignKey<Produto>(x => x.TipoId);
        }
    }
}
