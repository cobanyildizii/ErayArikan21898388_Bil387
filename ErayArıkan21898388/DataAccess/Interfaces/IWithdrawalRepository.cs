using DbFirst.Data;

namespace ErayArıkan21898388.DataAccess.Interfaces
{
    public interface IWithdrawalRepository
    {
        ICollection<Withdrawal> GetWithdrawals();
        Withdrawal GetWithdrawal(int id);
        bool IsWithdrawalExist(int id);
        bool Save();
        bool DeleteWithdrawal(Withdrawal withdrawal);
        bool CreateWithdrawal(Loan loan);
    }
}
