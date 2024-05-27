using Microsoft.EntityFrameworkCore;
using business.Logic.Domain.Models.Customers;
using business.Logic.Domain.Models.Users;
using business.Logic.Domain.Models.Notes;
using business.Logic.Domain.Models.NoteTags;
using business.Logic.Domain.Models.Orders;
using business.Logic.Domain.Models.FeedBack;
using Task = business.Logic.Domain.Models.Tasks.Task;
using business.Logic.Domain.Models.Tasks;

namespace business.DAL.EF
{
    public class PostgreeContext : DbContext
    {
        public PostgreeContext(DbContextOptions<PostgreeContext> options)
            : base(options)
        {
        }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<AspNetUsers> AspNetUsers { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteTag> NoteTags { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }

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
            modelBuilder.Entity<Order>()
                .HasOne(c => c.User)
                .WithMany()
                .IsRequired()
                .HasForeignKey(c => c.UserId);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.PaymentMethod)  // One Order has one PaymentMethod
                .WithMany()     // One PaymentMethod can have many Orders
                .IsRequired()
                .HasForeignKey(o => o.PaymentMethodId);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.OrderStatus)  // One Order has one PaymentMethod
                .WithMany()     // One PaymentMethod can have many Orders
                .IsRequired()
                .HasForeignKey(o => o.OrderStatusId);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)  // One Order has one PaymentMethod
                .WithMany()     // One PaymentMethod can have many Orders
                .IsRequired()
                .HasForeignKey(o => o.CustomerId);
            // связь FeedBack - Users
            modelBuilder.Entity<FeedBack>()
                .HasOne(c => c.User)
                .WithMany()
                .IsRequired()
                .HasForeignKey(c => c.UserId);
        }
    }
}