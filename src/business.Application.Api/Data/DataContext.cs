
using business.Application.Api.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace business.Application.Api.Data;

public sealed class DataContext : IdentityDbContext<ApplicationUser, IdentityRole<long>, long>
{
    public DataContext (DbContextOptions<DataContext> options)
        : base(options)
    {
    }
}