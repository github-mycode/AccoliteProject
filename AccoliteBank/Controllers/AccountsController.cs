using AccoliteBank.Dtos.Request.Account;
using AccoliteBank.Models.Accounts;
using AccoliteBank.Repository.Interfaces.Account;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AccoliteBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public AccountsController(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;            
            _mapper = mapper;
        }
        [HttpPost]
        [Route("create-account")]
        public async Task<string> CreateAccount([FromBody]CreateAccountDto createAccountDto)
        {
            string result = "";
            if (ModelState.IsValid)
            {
                var accountInfo = _mapper.Map<AccountModel>(createAccountDto);
                result = await _accountRepository.CreateAccount(accountInfo);
            }
           
            return result;
        }

        [HttpPut]
        [Route("update-account")]
        public async Task<string> UpdateAccount([FromBody] CreateAccountDto updateAccountDto)
        {
            string result = "";
            if (ModelState.IsValid)
            {
                var accountInfo = _mapper.Map<AccountModel>(updateAccountDto);
                result = await _accountRepository.UpdateAccount(accountInfo);
            }

            return result;
        }
        [HttpDelete]
        [Route("delete-account")]
        public async Task<bool> DeleteAccount([FromQuery]long accountId)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                result =  await _accountRepository.DeleteAccount(accountId);
            }

            return result;
        }

        [HttpGet]
        [Route("get-all-account-by-userid")]
        public async Task<List<AccountModel>> GetAllAccount([FromQuery] long userId)
        {

           var result =  await _accountRepository.GetAllAccount(userId);

            return result ;
        }

        [HttpGet]
        [Route("get-account-detail-by-accountid")]
        public async Task<AccountModel> GetAccountDetail([FromQuery] long accountId)
        {

            var result = await _accountRepository.GetAccountDetail(accountId);

            return result;
        }
    }
}
