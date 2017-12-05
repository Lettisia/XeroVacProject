using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using XeroProjectReact.Models;

namespace XeroProjectReact.Controllers
{
    public class CommandController : Controller
    {
        [HttpGet]
        [Route("/command")]
        public IActionResult Get()
        {
            return Ok(new { message = "hello" });
        }

        [HttpPost]
        [Route("/command")]
        public IActionResult RunCommand(string jsonStr)
        {
            Console.WriteLine(jsonStr);
            var cmd = JsonConvert.DeserializeObject<Command>(jsonStr);
            World world = World.GetInstance();
            String result = world.ExecuteCommand(cmd);
            return Ok(result);
        }
    }
}