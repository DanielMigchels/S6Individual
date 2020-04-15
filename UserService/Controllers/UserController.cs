using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Models;
using UserService.Repositories;

namespace UserService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserRepository userRepository = new UserRepository();

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            return userRepository.Get(id);
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] User value)
        {
            userRepository.Post(value);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            userRepository.Put(id, value);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            userRepository.Delete(id);
        }
    }
}
