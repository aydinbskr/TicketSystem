using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Concrete.EntityFramework.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.EmpoyeeId).IsRequired();

            builder.Property(e => e.EmpUserName).IsRequired();
            builder.Property(e => e.EmpUserName).HasMaxLength(50);

            builder.Property(e => e.EmpPassword).IsRequired();
            builder.Property(e => e.EmpPassword).HasMaxLength(50);

            builder.Property(e => e.EmpName).IsRequired();
            builder.Property(e => e.EmpName).HasMaxLength(50);

            builder.Property(e => e.EmpSurname).IsRequired();
            builder.Property(e => e.EmpSurname).HasMaxLength(50);

            builder.Property(e => e.EmpAddress).IsRequired(false);
            builder.Property(e => e.EmpAddress).HasMaxLength(500);

            builder.Property(e => e.EmpEmail).IsRequired(false);
            builder.Property(e => e.EmpEmail).HasMaxLength(100);

            builder.Property(e => e.EmpPhoneNumber).IsRequired(false);
            builder.Property(e => e.EmpPhoneNumber).HasMaxLength(20);

            builder.Property(e => e.EmpBirthDate).IsRequired(false);

            builder.HasKey(e => e.EmpoyeeId);

            builder.HasMany(e => e.Movies).WithOne(m => m.Employee).OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new Employee
            {
                EmpoyeeId = 1,
                EmpAddress = "Ankara",
                EmpEmail = "sncr.@html.com",
                EmpName = "Ismail",
                EmpSurname = "Bal",
                EmpBirthDate = DateTime.Now.AddMonths(1),
                EmpPassword = "Admin",
                EmpUserName = "Admin",
                EmpPhoneNumber = "0534543123"
            });
        }
    }
}
