using HospitalCA.Application.Common.Interfaces;
using HospitalCA.Domain.Entities;
using HospitalCA.Infrastructure.Persistence;

namespace Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly RoleDbContext context;

    public RoleRepository(RoleDbContext context)
    {
        this.context = context;
    }
    public IEnumerable<Role> Get()
    {
        return context.Roles;
    }

    public Role Get(int id)
    {
        return context.Roles.Find(id);
    }

    public void Create(Role role)
    {
        context.Roles.Add(role);
        context.SaveChanges();
    }

    public void Update(int id, Role role)
    {
        Role currentRole = Get(id);
        currentRole.Name = role.Name;
        context.Roles.Update(currentRole);
        context.SaveChanges();
    }

    public Role Delete(int id)
    {
        Role role = Get(id);
        if (role != null)
        {
            context.Roles.Remove(role);
            context.SaveChanges();
        }
        return role;
    }
}
