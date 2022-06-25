using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Concrete.EntityFramework.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.Property(t => t.TicketId).IsRequired();
            builder.Property(t => t.Price).IsRequired();
            builder.Property(t => t.Price).HasColumnType("money");

            builder.HasKey(t => t.TicketId);
            builder.HasOne(t => t.Customer).WithMany(c => c.Tickets).HasForeignKey(t => t.CustomerId);
            builder.HasOne(t => t.Session).WithMany(s => s.Tickets).HasForeignKey(t => t.SessionId);

        }
    }
}
