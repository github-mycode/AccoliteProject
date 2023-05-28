using AccoliteBank.Dtos.Request.User;
using AccoliteBank.Models.Users;
using Microsoft.EntityFrameworkCore.Internal;

namespace AccoliteBank.Repository.Interfaces.User
{
    public interface IUserRepository
    {
        public Task<UserModel> CreateUser(UserModel registerDto);
        public Task<UserModel> UpdateUser(UserModel registerDto);
        public Task<UserModel> LoginUser(LoginDto loginDto);
    }
}
