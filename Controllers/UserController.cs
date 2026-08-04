using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Wallet.DTOs;
using Wallet.Helpers;
using Wallet.Models;
using Wallet.Services;

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
            var user = _context.users.Find(Id);
            if (user == null) return NotFound();
            var userDto = new UserDto
            {
                Username = user.Username,
                Balance = user.Balance,
                Invest_amount = user.Invest_amount,
                Email = user.Email
            };

            return Ok(userDto);
        }
        [HttpGet("/invest_amount")]
        public IActionResult UserInvestment()
        {
            var investmentData = _context.Database.SqlQuery<UserInvestmentResult>(
            $"""
            select users.Username, isnull(sum(investments.Value),0) as Investment_Value 
            from users 
            left join investments on users.Id = investments.UserId 
            group by users.Username
            """
        ).ToList();
            return Ok(investmentData);
        }
        [HttpPost]
        public IActionResult Create(AuthDto authDto)
        {
            var newUser = new User()
            {
                Username = authDto.Username,
                Email = authDto.Email,
                Password = authDto.Password,
            };
            _context.users.Add(newUser);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPut]
        public IActionResult Update(UserDto userDto)
        {
            // Check the Implement 
            try
            {
                var user = _context.users.Find(1);
                if (user == null) return NotFound();
                user.Username = userDto.Username;
                user.Balance = userDto.Balance;
                user.Email = userDto.Email;
                _context.SaveChanges();
                return Ok(user);
            }
           catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
