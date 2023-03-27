using HospitalCA.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalCA.Infrastructure.Persistence;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}
