using HospitalCA.Domain.Entities;
using HospitalCA.Domain.Entities.Contracts;

namespace HospitalCA.WebUI.Converters;

public static class AccountDTOConverter
{
    public static IEnumerable<Account> ToAccounts(this IEnumerable<AccountContract> items)
    {
        return items
           .SelectMany(item => new[] { item.ToAccount() });
    }

    public static IEnumerable<AccountContract> ToAccountContracrs(this IEnumerable<Account> items)
    {
        return items
           .SelectMany(item => new[] { item.ToAccountContract() });
    }

    public static Account ToAccount(this AccountContract item)
    {
        if (item == null)
            return null;

        return new Account
        {
            Id = item.Id,
            Login = item.Login,
            Roles = new List<Role>(item.Roles),
        };
    }
    public static AccountContract ToAccountContract(this Account item)
    {
        if (item == null)
            return null;

        return new AccountContract
        {
            Id = item.Id,
            Login = item.Login,
            Roles = new List<Role>(item.Roles)
        };
    }
}
