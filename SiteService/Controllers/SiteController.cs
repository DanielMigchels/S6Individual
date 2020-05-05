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
        public IActionResult Post([FromBody] Site value, [FromHeader] string jwt)
        {
            int userId = 0;
            try
            {
                userId = Shared.Jwt.JwtUtility.ReadJwt(jwt);
            }
            catch { return BadRequest("Not Authorized."); }

            value.Id = 0;
            value.UserId = userId;
            value.Created = DateTime.Now;

            siteRepository.Post(value);

            return Ok();
        }
    }
}
