using Microsoft.EntityFrameworkCore;

namespace CustomersApp.Database.Entities
{
    public class CustomerDbContext : DbContext
    {

        public CustomerDbContext()
        {

        }
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; } = default!;
        public DbSet<Address> Addresses { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            _ = optionsBuilder.UseSqlServer();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Customer>()
                .Property(c => c.NIP)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Customer>()
               .HasIndex(n => n.NIP)
               .IsUnique();


            modelBuilder.Entity<Address>()
                .Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Address>()
                .Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(50);



        }


    }
}
