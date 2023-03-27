using HospitalCA.Domain.Entities;

namespace HospitalCA.Application.Common.Interfaces;

public interface IAccountService
{
    public IEnumerable<Account> Get();

    public Account Get(int id);

    public void Create(Account account);

    public void Update(int UserId, Account updatedAccount);

    public Account Delete(int UserId);

}
