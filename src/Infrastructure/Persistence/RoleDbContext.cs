using HospitalCA.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalCA.Infrastructure.Persistence;

public class RoleDbContext : DbContext
{
    public RoleDbContext(DbContextOptions<RoleDbContext> options) : base(options)
    {
    }

    public DbSet<Role> Roles { get; set; }
}
