using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {

        [HttpGet("redirect")]
        public string Redirect()
        {
            return "redirected";
        }

        [HttpGet("auth")]
        [Authorize]
        public bool Auth()
        {
            return true;
        }
    }
}