using AccoliteBank.Dtos.Request.Transaction;
using AccoliteBank.Models.Accounts;
using AccoliteBank.Models.Transactions;
using AccoliteBank.Repository.Interfaces.Account;
using AccoliteBank.Repository.Interfaces.Transaction;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AccoliteBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : Controller
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        public TransactionsController(ITransactionRepository transactionRepository, IMapper mapper, IAccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _accountRepository = accountRepository;
        }
        [HttpPost]
        [Route("add-transaction")]
        public async Task<TransactionModel> AddTransaction([FromBody]TransactionDto transactionDto)
        {
            TransactionModel result = new();
            if (ModelState.IsValid)
            {
                var accountDetail = await _accountRepository.GetAccountDetail(transactionDto.AccountId);

                if (ValidateTransactionCondition(transactionDto, accountDetail))
                {
                    var transactionModel = _mapper.Map<TransactionModel>(transactionDto);
                    result = await  _transactionRepository.Transaction(transactionModel, accountDetail);
                }
              
            }
            return result;
        }

        [HttpGet]
        [Route("get-all-transaction")]
        public async Task<List<TransactionModel>> GetAllTransactions([FromQuery]long AccountId)
        {
            List<TransactionModel> result = new();
            if (ModelState.IsValid)
            {
                result = await _transactionRepository.GetAllTransaction(AccountId);
            }
            return result;
        }

        #region Private methods
        private bool ValidateTransactionCondition(TransactionDto transactionDto, AccountModel accountDetail)
        {
            if (transactionDto.DepositType == Enum.DepositType.Deposit)
            {
                
                if (transactionDto.Amount <= 10000 )
                {
                    accountDetail.AvailableBalance += transactionDto.Amount;
                }
                else
                {
                    throw new Exception(message:"Amount can be deposit more than $10000 in one go");
                }

            }
            else
            {
                if (transactionDto.Amount <= 0.9*(accountDetail.AvailableBalance) && accountDetail.AvailableBalance-transactionDto.Amount>100)
                {
                    accountDetail.AvailableBalance -= transactionDto.Amount;
                }
                else
                {
                    throw new Exception(message: "Amount can be withdrawal more than 90% of the available balance in one go");
                }

            }
            return true;
        }
        #endregion
    }


}
