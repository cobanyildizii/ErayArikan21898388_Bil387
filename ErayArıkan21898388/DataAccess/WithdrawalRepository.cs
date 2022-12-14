using DbFirst.Data;
using ErayArıkan21898388.Data;
using ErayArıkan21898388.DataAccess.Interfaces;

namespace ErayArıkan21898388.DataAccess
{
    public class WithdrawalRepository : IWithdrawalRepository
    {
        private readonly Datacontext _context;

        public WithdrawalRepository(Datacontext context)
        {
            _context = context;
        }

        public bool CreateWithdrawal(Loan loan)
        {
            _context.Add(loan);
            return Save();
        }

        public bool DeleteWithdrawal(Withdrawal withdrawal)
        {
            _context.Remove(withdrawal);
            return Save();
        }

        public Withdrawal GetWithdrawal(int id)
        {
            return _context.Withdrawals.Where(a => a.Id == id).FirstOrDefault();
        }

        public ICollection<Withdrawal> GetWithdrawals()
        {
            return _context.Withdrawals.ToList();
        }

        public bool IsWithdrawalExist(int id)
        {
            return _context.Withdrawals.Any(a => a.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
