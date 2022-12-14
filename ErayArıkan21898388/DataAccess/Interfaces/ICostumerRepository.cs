using DbFirst.Data;
using ErayArıkan21898388.Data;
using System.Diagnostics.Metrics;

namespace ErayArıkan21898388.DataAccess.Interfaces
{
    public interface ICostumerRepository
    {
        ICollection<Costumer> GetCostumers();
        Costumer GetCostumerById(int id);
        bool IsCostumerExist(int id);
        bool Save();
        bool CreateCostumer(Costumer costumer);
        bool DeleteCostumer(Costumer costumer);
        bool UpdateCostumer(Costumer costumer);
    }
}
