

using Microsoft.EntityFrameworkCore;
using business.Logic.Domain.Models.Client;

namespace business.DAL.EF
{
    public class PostgreeContext : DbContext
    {
        public PostgreeContext(DbContextOptions<PostgreeContext> options)
            : base(options)
        {
        }


        public DbSet<Client> Client => Set<Client>();
    }
}