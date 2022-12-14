using DbFirst.Data;
using ErayArıkan21898388.Data;
using ErayArıkan21898388.DataAccess.Interfaces;

namespace ErayArıkan21898388.DataAccess
{
    public class LoanRepository : ILoanRepository
    {
        private readonly Datacontext _context;

        public LoanRepository(Datacontext context)
        {
            _context = context;
        }

        public bool CreateLoan(Loan loan)
        {
            _context.Add(loan);
            return Save();
        }

        public bool DeleteLoan(Loan loan)
        {
            _context.Remove(loan);
            return Save();
        }

        public Loan GetLoanById(int id)
        {
            return _context.Loans.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Loan> GetLoans()
        {
            return _context.Loans.ToList();
        }

        public bool IsLoanExist(int id)
        {
            return _context.Loans.Any(l => l.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
