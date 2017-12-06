using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServerWebAppTombstone.Models;

namespace ServerWebAppTombstone.Controllers
{
    public class CommandController : Controller
    {
        /*
        [HttpGet]
        [Route("/command")]
        public IActionResult Get()
        {
            return Ok(new { message = "hello" });
        }*/

        [HttpGet]
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