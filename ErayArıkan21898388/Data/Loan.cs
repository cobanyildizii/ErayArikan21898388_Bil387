using ErayArıkan21898388.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbFirst.Data;

public partial class Loan
{
    [Key]
    public int? Id{ get; set; }

    public double? Interest { get; set; }

    public double? PaybackAmount { get; set; }

    public string? Type { get; set; }

    public DateTime? PaybackTime { get; set; }

    public Costumer? Costumer { get; set; }

}
