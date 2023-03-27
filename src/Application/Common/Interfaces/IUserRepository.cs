using HospitalCA.Domain.Entities;

namespace HospitalCA.Application.Common.Interfaces;

public interface IUserRepository
{
    IEnumerable<User> Get();
    User Get(int id);
    void Create(User user);
    void Update(int id, User user);
    User Delete(int id);
}
