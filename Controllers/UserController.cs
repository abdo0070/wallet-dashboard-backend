using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Wallet.DTOs;
using Wallet.Models;

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
        [HttpPost]
        public IActionResult Create(UserDto userDto)
        {
            var newUser = new User()
            {
                Username = userDto.Username,
                Email = userDto.Email,
                Password = userDto.Password,
                Token = ""
            };
            _context.users.Add(newUser);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPut]
        public IActionResult Update(User updatedUser)
        {
            // Check the Implement 
            var user = _context.users.Single(u => u.Id == updatedUser.Id);
            user = updatedUser;
            _context.users.Update(user);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            try
            {
                var user = _context.users.Single(u => u.Id == Id);
                _context.users.Remove(user);
                _context.SaveChanges();
                return NoContent();
            }
            catch{
                return NotFound();
            }
        }

    }
}
