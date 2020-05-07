using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using VoteService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VoteService.ViewModels;

namespace VoteService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoteController : ControllerBase
    {
        VoteRepository voteRepository = new VoteRepository();

        [HttpGet("{articleId}")]
        public IActionResult Get(int articleId)
        {
            IEnumerable<Vote> votes = voteRepository.GetArticle(articleId);

            if (votes.Count() == 0)
            {
                return BadRequest("No votes.");
            }

            return Ok(new VoteResultViewModel()
            {
                Percentage = (100 / votes.Where(vote => vote.Rating == 1).Count() / votes.Count()) * votes.Count(),
                Count = votes.Count()
            });
        }

        [HttpPost]
        public IActionResult Post([FromBody] Vote value, [FromHeader] string jwt)
        {
            int userId = 0;
            try
            {
                userId = Shared.Jwt.JwtUtility.ReadJwt(jwt);
            }
            catch { return BadRequest("Not Authorized."); }

            IEnumerable<Vote> votes = voteRepository.GetUser(userId);
            foreach(Vote vote in votes)
            {
                if (vote.ArticleId == value.ArticleId)
                {
                    return BadRequest("Already voted for this article.");
                }
            }

            value.Id = 0;
            value.UserId = userId;
            value.Created = DateTime.Now;

            voteRepository.Post(value);

            return Ok();
        }

    }
}
