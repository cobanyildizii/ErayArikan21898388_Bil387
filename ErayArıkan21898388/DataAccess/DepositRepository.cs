using DbFirst.Data;
using ErayArıkan21898388.Data;
using ErayArıkan21898388.DataAccess.Interfaces;

namespace ErayArıkan21898388.DataAccess
{
    public class DepositRepository : IDepositRepository
    {
        private Datacontext _context;
        public DepositRepository(Datacontext context)
        {
            _context = context;
        }

        public bool CreateDeposit(Deposit deposit)
        {
            _context.Add(deposit);
            return Save();
        }

        public bool DeleteDeposit(Deposit deposit)
        {
            _context.Remove(deposit);
            return Save();
        }

        public Deposit GetDeposit(int id)
        {
            return _context.Deposits.Where(d => d.Id == id).FirstOrDefault();
        }

        public ICollection<Deposit> GetDeposits()
        {
            return _context.Deposits.ToList();
        }

        public bool IsDepositExist(int id)
        {
            return _context.Accounts.Any(a => a.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
