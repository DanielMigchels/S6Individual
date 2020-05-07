using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Models
{
    public class Vote
    {
        public int Id { get; set; }

        public int ArticleId { get; set; }

        public int Rating { get; set; }

        public int UserId { get; set; }

        public DateTime Created { get; set; }
    }
}
