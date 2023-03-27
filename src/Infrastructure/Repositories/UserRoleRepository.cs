using HospitalCA.Application.Common.Interfaces;
using HospitalCA.Domain.Entities;
using HospitalCA.Infrastructure.Persistence;

namespace HospitalCA.Infrastructure.Repositories;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly UserRoleDbContext context;

    public UserRoleRepository(UserRoleDbContext context)
    {
        this.context = context;
    }
    public IEnumerable<UserRole> Get()
    {
        return context.UsersRoles;
    }

    public UserRole Get(int id)
    {
        return context.UsersRoles.Find(id);
    }

    public void Create(UserRole userRole)
    {
        context.UsersRoles.Add(userRole);
        context.SaveChanges();
    }

    public void Update(int id, UserRole userRole)
    {
        UserRole currentUserRole = Get(id);
        currentUserRole.UserId = userRole.UserId;
        currentUserRole.RoleId = userRole.RoleId;
        context.UsersRoles.Update(currentUserRole);
        context.SaveChanges();
    }

    public UserRole Delete(int id)
    {
        UserRole userRole = Get(id);
        if (userRole != null)
        {
            context.UsersRoles.Remove(userRole);
            context.SaveChanges();
        }
        return userRole;
    }
}
