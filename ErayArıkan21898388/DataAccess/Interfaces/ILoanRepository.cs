using DbFirst.Data;
using ErayArıkan21898388.Data;

namespace ErayArıkan21898388.DataAccess.Interfaces
{
    public interface ILoanRepository
    {
        ICollection<Loan> GetLoans();
        Loan GetLoanById(int id);
        bool IsLoanExist(int id);
        bool CreateLoan(Loan loan);
        bool Save();
        bool DeleteLoan(Loan loan);
    }
}
