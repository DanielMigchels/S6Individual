using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace UserService.Repositories
{
    interface IUserContext
    {
        public User Get(int id);
        public User Get(string username);
        public void Post(User value);
        public void Put(int id, User value);
        public void Delete(int id);
    }
}
