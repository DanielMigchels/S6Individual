using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoteService.Models;
using VoteService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace VoteService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoteController : ControllerBase
    {
        VoteRepository VoteRepository = new VoteRepository();

        // GET: api/Vote
        [HttpGet]
        public IEnumerable<Vote> Get()
        {
            return VoteRepository.Get();
        }

        // GET: api/Vote/5
        [HttpGet("{id}", Name = "Get")]
        public Vote Get(int id)
        {
            return VoteRepository.Get(id);
        }

        // POST: api/Vote
        [HttpPost]
        public void Post([FromBody] Vote value)
        {
            VoteRepository.Post(value);
        }

        // PUT: api/Vote/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Vote value)
        {
            VoteRepository.Put(id, value);
        }

        // DELETE: api/Vote/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            VoteRepository.Delete(id);
        }
    }
}
