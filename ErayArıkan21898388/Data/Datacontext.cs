using System;
using System.Collections.Generic;
using DbFirst.Data;
using Microsoft.EntityFrameworkCore;

namespace ErayArıkan21898388.Data;

public class Datacontext : DbContext
{
    public Datacontext(DbContextOptions<Datacontext> options) : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }

    public DbSet<Costumer> Costumers { get; set; }

    public DbSet<Deposit> Deposits { get; set; }

    public DbSet<Loan> Loans { get; set; }

    public DbSet<Transaction> Transactions { get; set; }

    public DbSet<Withdrawal> Withdrawals { get; set; }

}
