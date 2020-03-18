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
            version.Version = "1.0.0.0";

            string json = HttpResponse.Success(version);
            return Ok(json);
        }
    }
}