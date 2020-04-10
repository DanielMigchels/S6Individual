using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Repositories
{
    interface IUserContext
    {
        public IEnumerable<User> Get();
        public User Get(int id);
        public void Post(User value);
        public void Put(int id, User value);
        public void Delete(int id);
    }
}
