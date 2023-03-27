using Microsoft.OpenApi.Extensions;
using HospitalCA.Domain.Enums;
using HospitalCA.Domain.Entities;
using HospitalCA.Infrastructure.Common.Helpers;

namespace HospitalCA.Infrastructure.Repositories;

public static class FakeDB
{
    public static List<Doctor> Doctors { get; set; }
    public static List<Account> Accounts { get; set; }

    static FakeDB()
    {
        Doctors = GetDoctors();
        Accounts = GetAccounts();
    }


    private static List<Doctor> GetDoctors(int halfCount = 4)
    {
        var doctors = new List<Doctor>();
        for (int i = 0; i < halfCount; i++)
        {
            doctors.Add(
                new Doctor
                {
                    Id = i,
                    Login = $"admin{i}",
                    FirstName = $"Name{i}",
                    LastName = $"Surname{i}",
                    Email = $"admin{i}@email"
                });

            doctors.Add(
                new Doctor
                {
                    Id = i + halfCount,
                    Login = $"doctor{i + halfCount}",
                    FirstName = $"Name{i + halfCount}",
                    LastName = $"Surname{i + halfCount}",
                    Email = $"doctor{i + halfCount}@email"
                });
        }
        return doctors;
    }

    private static List<Account> GetAccounts(int halfCount = 4)
    {
        var accounts = new List<Account>();
        for (int i = 0; i < halfCount; i++)
        {
            accounts.Add(
                new Account
                {
                    Id = i,
                    Login = $"admin{i}",
                    Password = AuthHelper.GetHashString($"password{i}"),
                    Roles = new List<Role> {
                        new Role{
                            Id = 1,
                            Name = RoleName.Admin.GetDisplayName()
                        }
                    }
                });
       
            accounts.Add(
                new Account
                {
                    Id = i + halfCount,
                    Login = $"doctor{i + halfCount}",
                    Password = AuthHelper.GetHashString($"password{i + halfCount}"),
                    Roles = new List<Role> {
                        new Role{
                            Id = 2,
                            Name = RoleName.User.GetDisplayName()
                        }
                    }
                });
        }
        return accounts;
    }
}
