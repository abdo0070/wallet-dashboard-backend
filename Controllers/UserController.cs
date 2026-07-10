using Microsoft.AspNetCore.Mvc;

namespace Wallet.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UserController : ControllerBase
    {
        private readonly WalletContext _context;
        public UserController(WalletContext walletContext)
        {
            this._context = walletContext;
        }
        [HttpGet]
        public IActionResult AllUsers()
        {
            var users = _context.users.ToList();
            return Ok(users);
        }
        [HttpGet("{Id}")]
        public IActionResult SingleUser(int Id)
        {
            return Ok(Id);
        }

    }
}
