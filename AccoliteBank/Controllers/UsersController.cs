using AccoliteBank.Db;
using AccoliteBank.Dtos.Request.User;
using AccoliteBank.Models.Users;
using AccoliteBank.Repository.Interfaces.User;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace AccoliteBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;            
            _mapper = mapper;
        }
        [HttpPost]
        [Route("register")]
        public async Task<UserModel> CreateUser([FromBody]RegisterDto registerDto)
        {
            UserModel result = new();
            if(ModelState.IsValid)
            {
                var userModel =  _mapper.Map<UserModel>(registerDto);   
                result=  await _userRepository.CreateUser(userModel);
            }

            return result;
        }

        [HttpPost]
        [Route("login")]
        public async Task<UserModel> Login([FromBody] LoginDto loginDto)
        {
            UserModel result = new();
            if (ModelState.IsValid)
            {
                result = await _userRepository.LoginUser(loginDto); 
            }
            return result;
        }

        [HttpPut]
        [Route("update-user")]
        public async Task<UserModel> UpdateUser([FromBody] RegisterDto registerDto)
        {
            UserModel result = new();
            if (ModelState.IsValid)
            {
              var userModel = _mapper.Map<UserModel>(registerDto);
              result =  await _userRepository.UpdateUser(userModel);

            }
            return result;
        }

    }
}
