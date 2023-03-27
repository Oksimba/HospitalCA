using HospitalCA.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalCA.Infrastructure.Persistence;

public class DoctorDbContext : DbContext
{
    public DoctorDbContext(DbContextOptions<DoctorDbContext> options) : base(options)
    {
    }

    public DbSet<Doctor> Doctors { get; set; }
}
