using Microsoft.EntityFrameworkCore;
using business.Logic.Domain.Models.Customer;
using business.Logic.Domain.Models.Users;
using business.Logic.Domain.Models.Notes;

namespace business.DAL.EF
{
    public class PostgreeContext : DbContext
    {
        public PostgreeContext(DbContextOptions<PostgreeContext> options)
            : base(options)
        {
        }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка модели
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.User)
                .WithMany()
                .IsRequired()
                .HasForeignKey(c => c.UserId);
            modelBuilder.Entity<Note>()
                .HasOne(c => c.User)
                .WithMany()
                .IsRequired()
                .HasForeignKey(c => c.UserId);
        }
    }
}