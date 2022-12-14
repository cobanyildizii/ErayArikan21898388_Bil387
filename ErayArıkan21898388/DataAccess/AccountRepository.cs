using AutoMapper;
using DbFirst.Data;
using ErayArıkan21898388.Data;
using ErayArıkan21898388.DataAccess.Interfaces;
using ErayArıkan21898388.Dto;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace ErayArıkan21898388.DataAccess
{
    public class AccountRepository : IAccountRepository
    {
        private readonly Datacontext _context;
       
        public AccountRepository(Datacontext context)
        {
            _context = context;
        }

        public bool AccountsExist(int id)
        {
            return _context.Accounts.Any(a => a.Id == id);
        }

        public bool CreateAccount(Account account)
        {
            _context.Add(account);
            return Save();
        }

        public Account GetAccount(int id)
        {
            return _context.Accounts.Where(a => a.Id == id).FirstOrDefault();
        }

        public Account GetAccountTrimToUpper(AccountDto accountCreate)
        {
            return GetAccounts().Where(a => a.Type.Trim().ToUpper() == accountCreate.Type.TrimEnd().ToUpper()).FirstOrDefault();
        }

        public ICollection<Account> GetAccounts()
        {
            return _context.Accounts.OrderBy(a => a.Id).ToList();
        }

        public decimal GetBalance(int id)
        {
            var balance = _context.Accounts.Where(a => a.Id == id);
            
            return ((decimal)balance.Sum(b=>b.Balance)/balance.Count());
        }

        public bool IsAccountPositive(int id)
        {
            var balance = _context.Accounts.Where(a => a.Id == id);
            if (balance.Count() > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool DeleteAccount(Account account)
        {
            _context.Remove(account);
            return Save();
        }

        public bool UpdateAccount(Account account)
        {
            _context.Update(account);
            return Save();
        }
    }
}
