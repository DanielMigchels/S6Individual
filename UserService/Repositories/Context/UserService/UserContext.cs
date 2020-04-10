using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Repositories.Context.UserService
{
    public class UserContext : IUserContext
    {
        public void Delete(int id)
        {
            User user = UserServiceContext.current.User.Single(p => p.Id == id);
            UserServiceContext.current.User.Remove(user);
            UserServiceContext.current.SaveChanges();
        }

        public IEnumerable<User> Get()
        {
            return UserServiceContext.current.User;
        }

        public User Get(int id)
        {
            return UserServiceContext.current.User.Single(p => p.Id == id);
        }

        public void Post(User value)
        {
            UserServiceContext.current.User.Add(value);
            UserServiceContext.current.SaveChanges();
        }

        public void Put(int id, User value)
        {
            User user = UserServiceContext.current.User.Single(p => p.Id == id);
            user = value;
            user.Id = id;
            UserServiceContext.current.SaveChanges();
        }
    }
}
