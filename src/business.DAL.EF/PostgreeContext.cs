using Microsoft.EntityFrameworkCore;
using business.Logic.Domain.Models.Customer;
using business.Logic.Domain.Models.Users;
using business.Logic.Domain.Models.Notes;
using business.Logic.Domain.Models.NoteTags;

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
        public DbSet<NoteTag> NoteTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка модели
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.User)
                .WithMany()
                .IsRequired()
                .HasForeignKey(c => c.UserId);
            // связь Notes - Users
            modelBuilder.Entity<Note>()
                .HasOne(c => c.User)
                .WithMany()
                .IsRequired()
                .HasForeignKey(c => c.UserId);
            // связь Notes - NoteTags
            modelBuilder.Entity<Note>()
                .HasOne(c => c.NoteTags)
                .WithMany()
                .IsRequired()
                .HasForeignKey(c => c.TagId);
            // связь NoteTags - Users
            modelBuilder.Entity<NoteTag>()
                .HasOne(c => c.User)
                .WithMany()
                .IsRequired()
                .HasForeignKey(c => c.UserId);
        }
    }
}