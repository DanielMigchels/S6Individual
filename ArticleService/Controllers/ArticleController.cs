using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using ArticleService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ArticleService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        ArticleRepository articleRepository = new ArticleRepository();

        [HttpGet("Site/{id}")]
        public IEnumerable<Article> GetSite(int id)
        {
            return articleRepository.GetSite(id);
        }

        [HttpGet]
        public object GetArticle(string url)
        {
            try
            {
                return articleRepository.Get(url);
            }
            catch
            {
                return BadRequest("Not Found");
            }
        }

        [HttpGet("Site/{id}/Page/{page}/PageSize/{pageSize}")]
        public IEnumerable<Article> GetSite(int id,int page, int pageSize)
        {
            return articleRepository.GetSite(id, page, pageSize);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Article value, [FromHeader] string jwt)
        {
            int userId = 0;
            try
            {
                userId = Shared.Jwt.JwtUtility.ReadJwt(jwt);
            }
            catch { return BadRequest("Not Authorized."); }

            try
            {
                articleRepository.Get(value.URI);
                return BadRequest("Already added!");
            }
            catch { }
            
            value.Id = 0;
            value.UserId = userId;
            value.Created = DateTime.Now;

            articleRepository.Post(value);

            return Ok();
        }
    }
}
