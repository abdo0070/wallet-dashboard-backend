using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Wallet.DTOs;
using Wallet.Models;
using Wallet.Services;

namespace Wallet.Controllers
{
    [ApiController]
    [Route("/investment")]
    [Authorize]
    public class InvestmentController : ControllerBase
    {
        private readonly WalletContext _context;
        public InvestmentController(WalletContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult AllUserInvestment()
        {
            var Id = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            try
            {
                var investments = _context.investments.Where((i) => i.UserId == Id).Join(
        _context.investmentTypes,         // Target table to join
        investment => investment.InvestmentTypeId,  // Foreign key from Investment
        type => type.Id,                   // Primary key from InvestmentType
        (investment, type) => new
        {
            investment,
            InvestmentType = type.Type
        }
    )
    .ToList();
                return Ok(investments);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }
        [HttpPost]
        public IActionResult CreateInvestment(int InvestmentTypeId)
        {
            try
            {
                // retrive the user and investtype 
                var Id = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var user = _context.users.Find(Id);
                var investType = _context.investmentTypes.Single((i) => i.Id == InvestmentTypeId);
                // create the new investment 
                var newInvestment = _context.investments.Add(new Models.Investment
                {
                    InvestmentTypeId = InvestmentTypeId,
                    UserId = Id,
                    investmentType = investType,
                    user = user
                });
                _context.SaveChanges();
                return Ok(newInvestment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult UpdateInvestment([FromBody]InvestmentDto investmentDto)
        {

            try
            {
                var investment = _context.investments.Find(investmentDto.Id);
                if (investment == null) return NotFound();
                // validate 
                var userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                if (userId != investment.UserId) return Unauthorized();
                investment.Value = investmentDto.Value;
                investment.Amount = investmentDto.Amount;
                investment.InvestmentTypeId = investmentDto.InvestmentTypeId;
                investment.Upated_at = DateTime.Now;
                _context.SaveChanges(); 
                return Ok(investment);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("{InvestmentId}")]
        public IActionResult AllDeleteInvestment(int InvestmentId)
        {
            // validate
            try
            {
                var investment = _context.investments.Find(InvestmentId);
                var userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                if (investment is null) return NotFound();
                if (userId != investment.UserId) return Unauthorized();
                _context.investments.Remove(investment);
                _context.SaveChanges();
                return NoContent();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
