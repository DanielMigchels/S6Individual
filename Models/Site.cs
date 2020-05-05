﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Site
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string DomainName { get; set; }

        public DateTime Created { get; set; }
    }
}
