using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using userWebApi.Model;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace userWebApi
{
    public class RegistrationMessage
    {
        public List<string> Messages { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class UserRegisterController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "I'm healthy";
        }

        [HttpPost]
        public IActionResult Post(UserData userData)
        {
            return Ok(userData.GetRegisteredMessage());
        }
    }
}
