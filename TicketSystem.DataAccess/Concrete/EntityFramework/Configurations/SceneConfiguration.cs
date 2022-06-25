using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Concrete.EntityFramework.Configurations
{
    public class SceneConfiguration : IEntityTypeConfiguration<Scene>
    {
        public void Configure(EntityTypeBuilder<Scene> builder)
        {
            builder.Property(s => s.SceneId).IsRequired();

            builder.Property(s => s.SceneType).IsRequired();
            builder.Property(s => s.SceneType).HasMaxLength(10);

            builder.HasKey(s => s.SceneId);

            builder.HasMany(sc => sc.Seats).WithOne(s => s.Scene).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(sc => sc.Sessions).WithOne(s => s.Scene).OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new Scene
            {
                SceneId = 1,
                SceneType = "Three-D"
            },
            new Scene
            {
                SceneId = 2,
                SceneType = "Normal"
            });
        }
    }
}
