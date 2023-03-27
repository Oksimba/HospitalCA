using HospitalCA.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalCA.Infrastructure.Persistence;

public class UserRoleDbContext : DbContext
{
    public UserRoleDbContext(DbContextOptions<UserRoleDbContext> options) : base(options)
    {
    }

    public DbSet<UserRole> UsersRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });
    }
}
