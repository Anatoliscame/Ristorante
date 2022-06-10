using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryEF.Configuration
{
    public class PiattoConfiguration : IEntityTypeConfiguration<Piatto>
    {
        public void Configure(EntityTypeBuilder<Piatto> builder)
        {
            builder.ToTable("Piatto");
            builder.HasKey(p => p.ID);
            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.Descrizione).IsRequired();
            builder.Property(p => p.Tipologia).IsRequired();
            builder.Property(p => p.Prezzo).IsRequired();


            builder.HasOne(m => m.Menu).WithMany(p => p.Piatti).HasForeignKey(m => m.MenuId);///.IsRequired(false);

        }
    }
}