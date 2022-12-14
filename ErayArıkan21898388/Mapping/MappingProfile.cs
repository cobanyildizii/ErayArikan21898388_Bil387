using AutoMapper;
using DbFirst.Data;
using ErayArıkan21898388.Data;
using ErayArıkan21898388.Dto;

namespace ErayArıkan21898388.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<Account, AccountDto>();
            CreateMap<Deposit, DepositDto>();
            CreateMap<Costumer, CostumerDto>();
            CreateMap<Withdrawal, WithdrawalDto>();
            CreateMap<Loan, LoanDto>();
            CreateMap<LoanDto, Loan>();
            CreateMap<AccountDto, Account>();
            CreateMap<CostumerDto,Costumer > ();
            CreateMap<DepositDto, Deposit>();
        }
    }
}
