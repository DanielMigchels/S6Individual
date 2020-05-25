using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ArticleTerminationService.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult GetVersion()
        {
            return Ok("Pong!");
        }
    }
}
