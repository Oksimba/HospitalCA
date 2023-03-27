using HospitalCA.Domain.Entities;

namespace HospitalCA.Application.Common.Interfaces;

public interface IUserRoleRepository
{
    IEnumerable<UserRole> Get();
    UserRole Get(int id);
    void Create(UserRole userRole);
    void Update(int id, UserRole userRole);
    UserRole Delete(int id);
}
