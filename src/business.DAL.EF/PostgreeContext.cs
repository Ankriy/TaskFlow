using Microsoft.EntityFrameworkCore;
using business.Logic.Domain.Models.Customer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using business.Logic.Domain.Models.User;

namespace business.DAL.EF
{
    public class PostgreeContext : DbContext
    {
        public PostgreeContext(DbContextOptions<PostgreeContext> options)
            : base(options)
        {
        }


        public DbSet<Customer> Client => Set<Customer>();
        public DbSet<User> Users { get; set; }
    }
}