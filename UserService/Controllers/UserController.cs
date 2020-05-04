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
            User user = userRepository.Get(value.username);

            if (Utilities.Pbkdf2Utility.ValidatePassword(value.password, user.Password))
            {
                string jwt = JwtUtility.GenerateJwt(user);

                return Ok(jwt);
            }

            return Forbid();
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User value)
        {
            value.Password = Utilities.Pbkdf2Utility.HashPassword(value.Password);

            userRepository.Post(value);

            return Ok();
        }
    }
}
