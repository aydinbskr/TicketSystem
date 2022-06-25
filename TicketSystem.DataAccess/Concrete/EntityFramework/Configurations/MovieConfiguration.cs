using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Concrete.EntityFramework.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(m => m.MovieId).IsRequired();

            builder.Property(m => m.MovieName).IsRequired();
            builder.Property(m => m.MovieName).HasMaxLength(100);

            builder.Property(m => m.MovieVisionDate).IsRequired();

            //builder.Property(m => m.MovieBanner).IsRequired();

            builder.Property(m => m.MovieIMDB).IsRequired(false);
            builder.Property(m => m.MovieAgeLimit).IsRequired(false);

            builder.Property(m => m.MovieReview).IsRequired(false);
            builder.Property(m => m.MovieReview).HasMaxLength(500);

            builder.HasKey(m => m.MovieId);
            builder.HasOne(m => m.Category).WithMany(c => c.Movies).HasForeignKey(m => m.MovieCategoryId);
            builder.HasOne(m => m.Employee).WithMany(e => e.Movies).HasForeignKey(m => m.EmployeeId);

            builder.HasMany(m => m.Sessions).WithOne(s => s.Movie).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
