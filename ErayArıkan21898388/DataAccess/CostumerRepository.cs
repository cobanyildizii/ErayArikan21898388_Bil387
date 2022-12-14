using DbFirst.Data;
using ErayArıkan21898388.Data;
using ErayArıkan21898388.DataAccess.Interfaces;
using System.Diagnostics.Metrics;
using System.Security.Principal;

namespace ErayArıkan21898388.DataAccess
{
    public class CostumerRepository : ICostumerRepository
    {
        private readonly Datacontext _context;

        public CostumerRepository(Datacontext context)
        {
            _context = context;
        }

        public bool CreateCostumer(Costumer costumer)
        {
            _context.Add(costumer);
            return Save();
        }

        public bool DeleteCostumer(Costumer costumer)
        {
            _context.Remove(costumer);
            return Save();
        }

        public Costumer GetCostumerById(int id)
        {
            return _context.Costumers.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Costumer> GetCostumers()
        {
            return _context.Costumers.ToList();
        }

        public bool IsCostumerExist(int id)
        {
            return _context.Costumers.Any(a => a.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCostumer(Costumer costumer)
        {
            _context.Update(costumer);
            return Save();
        }
    }
}
