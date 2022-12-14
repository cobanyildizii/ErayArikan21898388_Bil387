using ErayArıkan21898388.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbFirst.Data;

public  class Account
{
    [Key]
    public int Id { get; set; }

    public double? Balance { get; set; }

    public string? Type { get; set; }

    public double? Limit { get; set; }
    public ICollection<Deposit>? Deposits { get; set; }
    public ICollection<Withdrawal>? Withdrawals { get; set; }
    public Costumer costumer { get; set; }

}
