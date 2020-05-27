using FavoDeMel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoDeMel.Infrastructure.EF.ModelsMap
{
    public class ComandaSituacaoMap : IEntityTypeConfiguration<ComandaSituacao>
    {
        public void Configure(EntityTypeBuilder<ComandaSituacao> builder)
        {
            builder.ToTable("ComandaSituacao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.Nome)
                .HasColumnName("Nome");
        }
    }
}
