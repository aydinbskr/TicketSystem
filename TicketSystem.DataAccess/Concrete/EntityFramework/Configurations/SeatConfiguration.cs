using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Concrete.EntityFramework.Configurations
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.Property(s => s.SeatId).IsRequired();
            builder.Property(s => s.SeatNumber).IsRequired();
            builder.Property(s => s.SessionId).IsRequired();

            builder.HasKey(s => s.SeatId);
            builder.HasIndex(s => new { s.SessionId, s.SeatNumber }).IsUnique();
            builder.HasOne(s => s.Scene).WithMany(sc => sc.Seats).HasForeignKey(s => s.SceneId);

        }
    }
}
