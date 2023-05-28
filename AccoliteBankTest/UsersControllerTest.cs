using AccoliteBank.Controllers;
using AccoliteBank.Dtos.Request.User;
using AccoliteBank.Enum;
using AccoliteBank.Models.Users;
using AccoliteBank.Repository.Interfaces.User;
using AutoMapper;
using Moq;


namespace AccoliteBankTest
{
    [TestClass]
    public class UsersControllerTest
    {
        private readonly UsersController _usersController;
        private Mock<IUserRepository> userRepo;
        private Mock<IMapper> mapper;
        public UsersControllerTest()
        {

            userRepo = new Mock<IUserRepository>();
            mapper = new Mock<IMapper>();
            _usersController = new UsersController(userRepo.Object,mapper.Object) ;

        }

        [TestMethod]
        public void CreateUser_ReturnUserModel()
        {
            RegisterDto registerDto = new RegisterDto()
            {

                Name = "xyz",
                Email = "xyz@gmail.com",
                ContactNumber = "9876543210",
                DateOfBirth = DateTime.Now.AddYears(-25),
                Gender = Gender.Male,
                Password = "xyz@123"
            };
            UserModel userModel = new UserModel()
            {
                Name = "xyz",
                Email = "xyz@gmail.com",
                ContactNumber = "9876543210",
                DateOfBirth = DateTime.Now.AddYears(-25),
                Gender = Gender.Male,
                Password = "xyz@123",
                Created = DateTime.Now,
                IsActive = true
            };

            var mockResponse = userRepo.Setup(x => x.CreateUser(userModel)).ReturnsAsync(userModel);

            var response = _usersController.CreateUser(registerDto);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Login_ReturnUserModel()
        {
            LoginDto registerDto = new LoginDto()
            {

                EmailId = "xyz@gmail.com",
                Password = "xyz@123"
            };
            UserModel userModel = new UserModel()
            {
                Name = "xyz",
                Email = "xyz@gmail.com",
                ContactNumber = "9876543210",
                DateOfBirth = DateTime.Now.AddYears(-25),
                Gender = Gender.Male,
                Password = "xyz@123",
                Created = DateTime.Now,
                IsActive = true
            };

            var mockResponse = userRepo.Setup(x => x.CreateUser(userModel)).ReturnsAsync(userModel);

            var response = _usersController.Login(registerDto);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Update_ReturnUserModel()
        {
            RegisterDto registerDto = new RegisterDto()
            {

                Name = "xyz",
                Email = "xyz@gmail.com",
                ContactNumber = "9876543210",
                DateOfBirth = DateTime.Now.AddYears(-25),
                Gender = Gender.Male,
                Password = "xyz@123"
            };
            UserModel userModel = new UserModel()
            {
                Name = "xyz",
                Email = "xyz@gmail.com",
                ContactNumber = "9876543210",
                DateOfBirth = DateTime.Now.AddYears(-25),
                Gender = Gender.Male,
                Password = "xyz@123",
                Created = DateTime.Now,
                IsActive = true
            };

            var mockResponse = userRepo.Setup(x => x.CreateUser(userModel)).ReturnsAsync(userModel);

            var response = _usersController.UpdateUser(registerDto);

            Assert.IsNotNull(response);
        }
    }
}
