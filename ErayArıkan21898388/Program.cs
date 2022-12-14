using DbFirst.Data;
using Microsoft.EntityFrameworkCore;
using ErayAr�kan21898388.Data;
using ErayAr�kan21898388.DataAccess.Interfaces;
using ErayAr�kan21898388.DataAccess;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
         
        // Add services to the container.
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddScoped<IAccountRepository, AccountRepository>();
        builder.Services.AddScoped<ICostumerRepository, CostumerRepository>();
        builder.Services.AddScoped<IDepositRepository, DepositRepository>();
        builder.Services.AddScoped<IWithdrawalRepository, WithdrawalRepository>();
        builder.Services.AddScoped<LoanRepository, LoanRepository>();
        builder.Services.AddControllers();
        builder.Services.AddDbContext<Datacontext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}