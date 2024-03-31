using Microsoft.EntityFrameworkCore;
using business.Logic.Domain.Models.Customer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace business.DAL.EF
{
    public class PostgreeContext : IdentityDbContext
    {
        public PostgreeContext(DbContextOptions<PostgreeContext> options)
            : base(options)
        {
        }


        public DbSet<Customer> Client => Set<Customer>();
    }
}