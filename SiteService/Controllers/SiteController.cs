using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using SiteService.Repositories;

namespace SiteService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SiteController : ControllerBase
    {
        SiteRepository siteRepository = new SiteRepository();

        // GET: api/Site
        [HttpGet]
        public IEnumerable<Site> Get()
        {
            return siteRepository.Get();
        }

        // GET: api/Site/5
        [HttpGet("{id}", Name = "Get")]
        public Site Get(int id)
        {
            return siteRepository.Get(id);
        }

        // POST: api/Site
        [HttpPost]
        public void Post([FromBody] Site value)
        {
            siteRepository.Post(value);
        }

        // PUT: api/Site/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Site value)
        {
            siteRepository.Put(id, value);
        }

        // DELETE: api/Site/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            siteRepository.Delete(id);
        }
    }
}
