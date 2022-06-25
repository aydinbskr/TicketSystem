using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Concrete.EntityFramework
{
    public class AppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=TicketSystem;User ID = sa; Password =Ankara06!;");
            

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Movie>? Movies { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Session>? Sessions { get; set; }
        public DbSet<Ticket>? Tickets { get; set; }
        public DbSet<Scene>? Scenes { get; set; }
        public DbSet<Seat>? Seats { get; set; }
        public DbSet<Category>? Categories { get; set; }

    }
}
