using Microsoft.AspNetCore.Mvc;
using Wallet.DTOs;

namespace Wallet.Controllers
{
    [ApiController]
    [Route("/auth")]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Login(AuthDto auth)
        {
            // Implemention 
            return Ok();
        }
        public IActionResult Register(UserDto user)
        {
            // Implemention
            return NoContent();
        }
    }
}
