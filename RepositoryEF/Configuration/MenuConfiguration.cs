using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryEF.Configuration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu");
            builder.HasKey(m => m.ID);
            builder.Property(m => m.Nome).IsRequired();


            builder.HasMany(p => p.Piatti).WithOne(m => m.Menu).HasForeignKey(p => p.MenuId);

        }
    }
}