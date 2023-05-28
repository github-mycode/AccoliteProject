using AccoliteBank.Controllers;
using AccoliteBank.Dtos.Request.Transaction;
using AccoliteBank.Enum;
using AccoliteBank.Models.Accounts;
using AccoliteBank.Models.Transactions;
using AccoliteBank.Repository.Interfaces.Account;
using AccoliteBank.Repository.Interfaces.Transaction;
using AutoMapper;
using Moq;

namespace AccoliteBankTest
{
    [TestClass]
    public class TransactionControllerTest
    {
        private readonly TransactionsController _transactionController;
        private Mock<IAccountRepository> accountRepository;
        private Mock<IMapper> mapper;
        private Mock<ITransactionRepository> transactionRepository;
        public TransactionControllerTest()
        {
            mapper = new Mock<IMapper>();
            transactionRepository = new Mock<ITransactionRepository>();
            accountRepository = new Mock<IAccountRepository>();
            _transactionController = new TransactionsController(transactionRepository.Object,mapper.Object,accountRepository.Object);
        }

        [TestMethod]
        public void AddTransactionTestMethod()
        {
            TransactionModel transactionModel = new TransactionModel()
            {
                TransactionId = 567,
                TransactionTime = DateTime.Now,
                AccountType = AccountType.Saving,
                Amount = 342,
                Status = TransactionStatusTypeId.Success,
                DepositType = DepositType.Deposit,
                CreationTime = DateTime.Now,
                AccountId = 324
            };
            TransactionDto transactionDto = new TransactionDto()
            {
                AccountType = AccountType.Saving,
                Amount = 123,
                DepositType = DepositType.Deposit,
                AccountId = 324
            };
            AccountModel accountModel = new AccountModel()
            {
                Id = new Guid(),
                AccountId = 4312,
                AvailableBalance = 123,
                AccountType = AccountType.Saving,
                IsActive = true,
                UserId = 4322
            };

            var accountResponse = accountRepository.Setup(x => x.GetAccountDetail(123)).ReturnsAsync(accountModel);
            var mockResponse = transactionRepository.Setup(x => x.Transaction(transactionModel, accountModel)).ReturnsAsync(transactionModel);
            var result = _transactionController.AddTransaction(transactionDto);
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void GetTransactionTestMethod()
        {
            List<TransactionModel> transactionModel = new List<TransactionModel>()
           {
               new TransactionModel(){
               TransactionId = 567,
               TransactionTime = DateTime.Now,
               AccountType = AccountType.Saving,
               Amount = 342,
               Status = TransactionStatusTypeId.Success,
               DepositType = DepositType.Deposit,
               CreationTime = DateTime.Now,
               AccountId = 324
               }
           };

            var mockResponse = transactionRepository.Setup(x => x.GetAllTransaction(123)).ReturnsAsync(transactionModel);

            var result = _transactionController.GetAllTransactions(123);
            Assert.IsNotNull(result);

        }
    }
}
