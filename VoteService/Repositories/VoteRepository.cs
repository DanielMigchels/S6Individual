using Models;
using VoteService.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoteService.Repositories
{
    public class VoteRepository
    {
        IVoteContext context = new Context.VoteService.VoteContext();

        public IEnumerable<Vote> Get() => context.Get();
        public Vote Get(int id) => context.Get(id);
        public void Post(Vote value) => context.Post(value);
        public void Put(int id, Vote value) => context.Put(id, value);
        public void Delete(int id) => context.Delete(id);
    }
}
