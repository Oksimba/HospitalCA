using HospitalCA.Domain.Entities;

namespace HospitalCA.Application.Common.Interfaces;

public interface IRoleRepository
{
    IEnumerable<Role> Get();
    Role Get(int id);
    void Create(Role role);
    void Update(int id, Role role);
    Role Delete(int id);
}
