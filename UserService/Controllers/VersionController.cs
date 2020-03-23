using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserService.ViewModel;

namespace UserService.Controllers
{
    public class VersionController : Controller
    {
        [HttpGet("/")]
        public IActionResult GetVersion()
        {
            VersionViewModel version = new VersionViewModel();

            string json = HttpResponse.Success(version);
            return Ok(json);
        }
    }
}