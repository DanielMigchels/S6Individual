using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.ViewModel
{
    public class LoggedInViewModel
    {
        public User User { get; set; }

        public string JWT { get; set; }
    }
}
