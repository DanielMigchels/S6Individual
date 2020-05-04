using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models;
using Shared.Jwt;
using UserService.Repositories;
using UserService.ViewModel;

namespace UserService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserRepository userRepository = new UserRepository();

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginViewModel value)
        {
            try
            {
                User user = userRepository.Get(value.username).Copy();

                if (Utilities.Pbkdf2Utility.ValidatePassword(value.password, user.Password))
                {
                    user.Password = string.Empty;

                    string jwt = JwtUtility.GenerateJwt(user);

                    LoggedInViewModel loggedInViewModel = new LoggedInViewModel()
                    {
                        JWT = jwt,
                        User = user
                    };

                    return Ok(loggedInViewModel);
                }
            }
            catch {  }
            
            return BadRequest("Invalid Username or Password");
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User value)
        {
            User user;
            try
            {
                user = userRepository.Get(value.Username).Copy();
                return BadRequest("User already exists.");
            }
            catch { }

            value.Password = Utilities.Pbkdf2Utility.HashPassword(value.Password);

            userRepository.Post(value);

            user = userRepository.Get(value.Username).Copy();
            user.Password = string.Empty;

            return Ok(user);
        }
    }
}
