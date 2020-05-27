using FavoDeMel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoDeMel.Infrastructure.EF.ModelsMap
{
    public class ComandaMap : IEntityTypeConfiguration<Comanda>
    {
        public void Configure(EntityTypeBuilder<Comanda> builder)
        {
            builder.ToTable("Comanda");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Numero)
                .HasColumnName("Numero");

            builder.Property(x => x.SituacaoId)
                .HasColumnName("SituacaoId");

            builder.HasOne(x => x.Situacao)
                .WithOne()
                .HasPrincipalKey<ComandaSituacao>(x => x.Id)
                .HasForeignKey<Comanda>(x => x.SituacaoId);

            builder
               .HasMany(e => e.Movimentos)
               .WithOne(e => e.Comanda)
               .HasPrincipalKey(e => e.Id)
               .HasForeignKey(e => e.ComandaId);
        }
    }
}
