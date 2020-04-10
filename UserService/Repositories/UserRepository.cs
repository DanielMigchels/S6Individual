using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Repositories
{
    public class UserRepository
    {
        IUserContext context = new Context.MySQL.UserContext();

        public IEnumerable<User> Get() => context.Get();
        public string Get(int id) => context.Get(id);
        public void Post(User value) => context.Post(value);
        public void Put(int id, User value) => context.Put(id, value);
        public void Delete(int id) => context.Delete(id);
    }
}
