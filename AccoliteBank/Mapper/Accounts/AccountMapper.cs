using AccoliteBank.Dtos.Request.Account;
using AccoliteBank.Models.Accounts;
using AutoMapper;

namespace AccoliteBank.Mapper.Accounts
{
    public class AccountMapper : Profile
    {
        public AccountMapper()
        {
            CreateMap<CreateAccountDto, AccountModel>();
            
        }
    }
}
