using Microsoft.EntityFrameworkCore;
using business.Logic.Domain.Models.Customer;
using business.Logic.Domain.Models.Users;

namespace business.DAL.EF
{
    public class PostgreeContext : DbContext
    {
        public PostgreeContext(DbContextOptions<PostgreeContext> options)
            : base(options)
        {
        }


        public DbSet<Customer> Customer => Set<Customer>();
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка модели
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.User)
                .WithMany()
                .IsRequired()
                .HasForeignKey(c => c.UserId);
        }
    }
}