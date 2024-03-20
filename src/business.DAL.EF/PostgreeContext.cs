using Microsoft.EntityFrameworkCore;
using business.Logic.Domain.Models.Customer;

namespace business.DAL.EF
{
    public class PostgreeContext : DbContext
    {
        public PostgreeContext(DbContextOptions<PostgreeContext> options)
            : base(options)
        {
        }


        public DbSet<Customer> Client => Set<Customer>();
    }
}