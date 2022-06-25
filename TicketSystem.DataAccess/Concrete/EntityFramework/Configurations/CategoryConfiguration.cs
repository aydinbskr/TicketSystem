using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Concrete.EntityFramework.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.CategoryId).IsRequired();
            builder.Property(c => c.CategoryName).IsRequired();
            builder.Property(c => c.CategoryName).HasMaxLength(100);

            builder.HasKey(c => c.CategoryId);
            builder.HasMany(c => c.Movies).WithOne(m => m.Category).OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new Category
            {
                CategoryId = 1,
                CategoryName = "Science Fiction",
            }, new Category
            {
                CategoryId = 2,
                CategoryName = "Romantic"
            }, new Category
            {
                CategoryId = 3,
                CategoryName = "Comedy"
            }, new Category
            {
                CategoryId = 4,
                CategoryName = "Horror"
            });
        }
    }
}
