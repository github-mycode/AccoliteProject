using AccoliteBank.Controllers;
using AccoliteBank.Dtos.Request.Account;
using AccoliteBank.Enum;
using AccoliteBank.Models.Accounts;
using AccoliteBank.Repository.Account;
using AccoliteBank.Repository.Interfaces.Account;
using AutoMapper;
using Moq;

namespace AccoliteBankTest
{
    [TestClass]
    public class AccountControllerTest
    {

        private readonly AccountsController _accountController;
        private Mock<IAccountRepository> accountRepository   ;
        private Mock<IMapper> mapper;
        public AccountControllerTest()
        {
            accountRepository = new Mock<IAccountRepository>();
            mapper = new Mock<IMapper>();
            _accountController = new AccountsController(accountRepository.Object, mapper.Object);



        }


        [TestMethod]
        public void CreateAccountTestMethod()
        {
            CreateAccountDto createAccountDto = new CreateAccountDto()
            {
                AvailableBalance = 123,
                AccountType = AccountType.Saving,
                IsActive = true,
                UserId = 4322
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

            var mockResponse = accountRepository.Setup(x => x.CreateAccount(accountModel)).ReturnsAsync("Added is created successfully");
            var result =  _accountController.CreateAccount(createAccountDto);
            Assert.IsNotNull(result, "Added is created successfully");
        }
        [TestMethod]
        public void UpdateAccountTestMethod()
        {
            CreateAccountDto createAccountDto = new CreateAccountDto()
            {
                AvailableBalance = 123,
                AccountType = AccountType.Saving,
                IsActive = true,
                UserId = 4322
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

            var mockResponse = accountRepository.Setup(x => x.CreateAccount(accountModel)).ReturnsAsync("Account Updated Successfully");
            var result = _accountController.CreateAccount(createAccountDto);
            Assert.IsNotNull(result, "Account Updated Successfully");
        }
        [TestMethod]
        public void DeleteAccountTestMethod()
        {
            var mockResponse = accountRepository.Setup(x => x.DeleteAccount(123)).ReturnsAsync(true);
            var result = _accountController.DeleteAccount(123);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetAllAccountTestMethod()
        {
            List<AccountModel> accountModel = new List<AccountModel>()
            { new AccountModel() {
                Id = new Guid(),
                AccountId = 4312,
                AvailableBalance = 123,
                AccountType = AccountType.Saving,
                IsActive = true,
                UserId = 4322
            } };
            var mockResponse = accountRepository.Setup(x => x.GetAllAccount(123)).ReturnsAsync(accountModel);
            var result = _accountController.GetAllAccount(123);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAccountDetailTestMethod()
        {
            AccountModel accountModel = new AccountModel()
            {
                Id = new Guid(),
                AccountId = 4312,
                AvailableBalance = 123,
                AccountType = AccountType.Saving,
                IsActive = true,
                UserId = 4322
            };
            var mockResponse = accountRepository.Setup(x => x.GetAccountDetail(123)).ReturnsAsync(accountModel);
            var result = _accountController.GetAllAccount(123);
            Assert.IsNotNull(result);
        }
    }
}