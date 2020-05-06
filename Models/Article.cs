using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Article
    {
        public int Id { get; set; }

        public int SiteId { get; set; }

        public string URI { get; set; }

        public int UserId { get; set; }

        public DateTime Created { get; set; }
    }
}
