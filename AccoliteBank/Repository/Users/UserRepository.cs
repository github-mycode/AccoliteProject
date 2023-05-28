using AccoliteBank.Db;
using AccoliteBank.Dtos.Request.User;
using AccoliteBank.Models.Users;
using AccoliteBank.Repository.Interfaces.User;
using Microsoft.EntityFrameworkCore;

namespace AccoliteBank.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly BankDbContext _bankDbContext;
        public UserRepository(BankDbContext bankDbContext)
        {
            _bankDbContext = bankDbContext;            
        }
        public async Task<UserModel> CreateUser(UserModel registerDto)
        {
            try
            {
                var num = new Random();
                int ran_num = num.Next(1, 10000);
                registerDto.UserId = ran_num;
                registerDto.IsActive = true;
                await _bankDbContext.UserProfiles.AddAsync(registerDto);
                await _bankDbContext.SaveChangesAsync();

                return registerDto; //$"User is added successfully with userId {registerDto.UserId}";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<UserModel> UpdateUser(UserModel registerDto)
        {
            try
            {
                _bankDbContext.UserProfiles.Update(registerDto);
                await _bankDbContext.SaveChangesAsync();
                return registerDto; //"User Updated Successfully";
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<UserModel> LoginUser(LoginDto loginDto)
        {
            try
            {
                var query = await _bankDbContext.UserProfiles
                    .Where(
                    x => x.Email == loginDto.EmailId && x.Password == loginDto.Password).ToListAsync();
                if (query.Count == 1)
                {
                    return query[0];
                }
                return new UserModel();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
