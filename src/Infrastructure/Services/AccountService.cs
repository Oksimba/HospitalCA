using HospitalCA.Application.Common.Interfaces;
using HospitalCA.Domain.Entities;
using HospitalCA.Infrastructure.Repositories;

namespace HospitalCA.Infrastructure.Services;

public class AccountService : IAccountService
{
    IUserRepository userRepository;
    IRoleRepository roleRepository;
    IUserRoleRepository userRoleRepository;
    public AccountService(IUserRepository userRepository, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository)
    {

        this.userRepository = userRepository;
        this.roleRepository = roleRepository;
        this.userRoleRepository = userRoleRepository;
    }
    public IEnumerable<Account> Get()
    {
        return FakeDB.Accounts;
    }

    public Account Get(int id)
    {
        return Get().Where(a => a.Id == id).First();
    }

    public void Create(Account account)
    {
        //userRepository.Create(account);
    }

    public void Update(int UserId, Account updatedAccount)
    {

        //var user = userRepository.Get(UserId);

        //if (user != null)
        //    userRepository.Update(UserId, updatedAccount);
    }

    public Account Delete(int UserId)
    {
        //return userRepository.Delete(IUserIdd);
        return new Account();
    }
}
