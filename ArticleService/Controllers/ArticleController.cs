using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticleService.Models;
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

        // GET: api/Article
        [HttpGet]
        public IEnumerable<Article> Get()
        {
            return articleRepository.Get();
        }

        // GET: api/Article/5
        [HttpGet("{id}", Name = "Get")]
        public Article Get(int id)
        {
            return articleRepository.Get(id);
        }

        // POST: api/Article
        [HttpPost]
        public void Post([FromBody] Article value)
        {
            articleRepository.Post(value);
        }

        // PUT: api/Article/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Article value)
        {
            articleRepository.Put(id, value);
        }

        // DELETE: api/Article/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            articleRepository.Delete(id);
        }
    }
}
