using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Concrete.EntityFramework.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.CustomerId).IsRequired();

            builder.Property(c => c.Username).IsRequired();
            builder.Property(c => c.Username).HasMaxLength(100);

            builder.Property(c => c.Password).IsRequired();
            builder.Property(c => c.Password).HasMaxLength(100);

            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(100);

            builder.Property(c => c.Surname).IsRequired();
            builder.Property(c => c.Surname).HasMaxLength(100);

            builder.Property(c => c.Address).IsRequired(false);
            builder.Property(c => c.Address).HasMaxLength(500);

            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(100);

            builder.Property(c => c.PhoneNumber).IsRequired();
            builder.Property(c => c.PhoneNumber).HasMaxLength(100);

            builder.Property(c => c.Birthdate).IsRequired(false);

            builder.HasKey(c => c.CustomerId);
            builder.HasMany(c => c.Tickets).WithOne(t => t.Customer).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
