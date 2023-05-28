using AccoliteBank.Dtos.Request.User;
using AccoliteBank.Models.Users;
using AutoMapper;

namespace AccoliteBank.Mapper.Users
{
    public class UserMapper: Profile
    {
        public UserMapper()
        {
            CreateMap<RegisterDto, UserModel>();
        }
    }
}
