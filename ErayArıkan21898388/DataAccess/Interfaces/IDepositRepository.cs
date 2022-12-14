using DbFirst.Data;
using ErayArıkan21898388.Data;

namespace ErayArıkan21898388.DataAccess.Interfaces
{
    public interface IDepositRepository
    {
        ICollection<Deposit> GetDeposits();
        Deposit GetDeposit(int id);
        bool CreateDeposit(Deposit deposit);
        bool IsDepositExist(int id);
        bool Save();
        bool DeleteDeposit(Deposit deposit);
    }
}
