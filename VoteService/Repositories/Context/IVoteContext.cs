using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoteService.Repositories.Context
{
    public interface IVoteContext
    {
        public IEnumerable<Vote> Get();
        public Vote Get(int id);
        public IEnumerable<Vote> GetArticle(int articleId);
        public IEnumerable<Vote> GetUser(int userId);
        public void Post(Vote value);
        public void Put(int id, Vote value);
        public void Delete(int id);
    }
}
