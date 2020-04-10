using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Repositories.Context.MySQL
{
    public class UserContext : IUserContext
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Get()
        {
            return UserServiceContext.current.User;
        }

        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Post(User value)
        {
            throw new NotImplementedException();
        }

        public void Put(int id, User value)
        {
            throw new NotImplementedException();
        }
    }
}
