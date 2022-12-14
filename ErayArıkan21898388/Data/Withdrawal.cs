using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbFirst.Data;

public partial class Withdrawal
{
    [Key]
    public int? Id { get; set; }

    public double? Amount { get; set; }

    public int? AccountId { get; set; }

    public DateTime? Date { get; set; }

    public string? Comment { get; set; }
    public Account Account { get; set; }
}
