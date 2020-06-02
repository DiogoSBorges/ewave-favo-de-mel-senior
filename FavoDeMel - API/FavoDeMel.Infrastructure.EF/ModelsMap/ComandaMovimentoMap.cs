using FavoDeMel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoDeMel.Infrastructure.EF.ModelsMap
{
    public class ComandaMovimentoMap : IEntityTypeConfiguration<ComandaMovimento>
    {
        public void Configure(EntityTypeBuilder<ComandaMovimento> builder)
        {
            builder.ToTable("ComandaMovimento");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.DataAbertura)
                .HasColumnName("DataAbertura");

            builder.Property(x => x.DataFechamento)
                .HasColumnName("DataFechamento");

            builder.Property(x => x.ComandaId)
               .HasColumnName("ComandaId");

            builder.HasOne(x => x.Comanda)
                .WithMany(x => x.Movimentos)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.ComandaId);
            
        }
    }
}
