using DbFirst.Data;
using ErayArıkan21898388.Dto;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace ErayArıkan21898388.DataAccess.Interfaces
{
    public interface IAccountRepository
    {
        ICollection<Account> GetAccounts();

        Account GetAccount(int id);
        decimal GetBalance(int id);
        bool IsAccountPositive(int id);
        bool AccountsExist(int id);
        Account GetAccountTrimToUpper(AccountDto accountDto);
        public bool CreateAccount(Account account);
        bool Save();
        bool DeleteAccount(Account account);
        bool UpdateAccount(Account account);


    }
}
