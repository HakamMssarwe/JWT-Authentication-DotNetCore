using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWT.Demo.Data;
using JWT.Demo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWT.Demo.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IJWTAuthenticationManager jwtAuthenticationManager;
        public UserController(JWTDemoDbContext context, IJWTAuthenticationManager jwtAuthenticationManager)
        {
            DataAccess._context = context;
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }


        [AllowAnonymous] 
        [HttpPost]
        [Route("Authenticate")]
        public IActionResult Authenticate([FromBody] User user)
        {

            var token = jwtAuthenticationManager.Authenticate(user.Username, user.Password);
            
            if (token != null)
                return Ok(token);

            return Unauthorized();
        }


        [HttpGet]
        [Route("SayHello")]
        public IActionResult SayHello([FromBody] User user)
        {
            return Ok("Hello");
        }


    }
}
