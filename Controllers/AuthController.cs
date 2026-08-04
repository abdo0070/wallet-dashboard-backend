using Microsoft.AspNetCore.Mvc;
using Wallet.DTOs;
using Wallet.Services;

namespace Wallet.Controllers
{
    [ApiController]
    [Route("/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public IActionResult Login(AuthLoginRequest auth)
        {
            try
            {
                var res = _authService.Login(auth);
                return Ok(res);
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("/register")]
        public IActionResult Register(AuthRegisterRequest registerRequest)
        {
            try
            {
                _authService.Register(registerRequest);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
