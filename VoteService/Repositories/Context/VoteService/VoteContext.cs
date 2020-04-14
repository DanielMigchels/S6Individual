using VoteService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoteService.Repositories.Context.VoteService
{
    public class VoteContext : IVoteContext
    {
        public void Delete(int id)
        {
            Vote Vote = VoteServiceContext.current.Vote.Single(p => p.Id == id);
            VoteServiceContext.current.Vote.Remove(Vote);
            VoteServiceContext.current.SaveChanges();
        }

        public IEnumerable<Vote> Get()
        {
            return VoteServiceContext.current.Vote;
        }

        public Vote Get(int id)
        {
            return VoteServiceContext.current.Vote.Single(p => p.Id == id);
        }

        public void Post(Vote value)
        {
            VoteServiceContext.current.Vote.Add(value);
            VoteServiceContext.current.SaveChanges();
        }

        public void Put(int id, Vote value)
        {
            Vote Vote = VoteServiceContext.current.Vote.Single(p => p.Id == id);
            Vote.Id = id;
            VoteServiceContext.current.SaveChanges();
        }
    }
}
