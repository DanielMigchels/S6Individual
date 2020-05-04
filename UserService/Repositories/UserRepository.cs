using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace UserService.Repositories
{
    public class UserRepository
    {
        IUserContext context = new Context.UserService.UserContext();

        public User Get(int id) => context.Get(id);
        public User Get(string username) => context.Get(username);
        public void Post(User value) => context.Post(value);
        public void Put(int id, User value) => context.Put(id, value);
        public void Delete(int id) => context.Delete(id);
    }
}
