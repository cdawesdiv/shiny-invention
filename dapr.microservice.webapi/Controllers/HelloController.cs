using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dapr;

namespace dapr.microservice.webapi.Controllers
{
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet("hello")]
        public ActionResult<string> Get()
        {
            Console.WriteLine("Hello Called");
            return "Hello";
        }

        [HttpGet("world")]
        public ActionResult<string> GetWorld()
        {
            var returnString = DateTime.Now.ToString();
            Console.WriteLine(returnString);
            return returnString;
        }
    }

}