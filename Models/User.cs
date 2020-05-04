using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User Copy()
        {
            return new User()
            {
                Id = this.Id,
                Username = this.Username,
                Password = this.Password
            };
        }
    }
}
