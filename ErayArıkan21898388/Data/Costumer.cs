using DbFirst.Data;
using System.ComponentModel.DataAnnotations;

namespace ErayArıkan21898388.Data
{
    public class Costumer
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Password { get; set; }

        public ICollection<Account>? Accounts { get; set; }
        public ICollection<Loan>? Loans { get; set; }
    }
}
