using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wallet.Models;
using Wallet.Services;

namespace Wallet.Controllers
{
    [ApiController]
    [Route("/{id}/investment")]
    public class InvestmentController : ControllerBase
    {
        private readonly WalletContext _context;
        public InvestmentController(WalletContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult AllUserInvestment(int id)
        {
            try
            {
                var investments = _context.investments.Where((i) => i.UserId == id).Include(i => i.investmentType);
                return Ok(investments);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }
        [HttpPost]
        public IActionResult CreateInvestment(int InvestmentTypeId, int id)
        {
            try
            {
                // retrive the user and investtype 
                var user = _context.users.Single((u) => u.Id == id);
                var investType = _context.investmentTypes.Single((i) => i.Id == InvestmentTypeId);
                // create the new investment 
                var newInvestment = _context.investments.Add(new Models.Investment
                {
                    InvestmentTypeId = InvestmentTypeId,
                    UserId = id,
                    investmentType = investType,
                    user = user
                });
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("{InvestmentId}")]
        public IActionResult UpdateInvestment(int InvestmentId)
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        [Route("{InvestmentId}")]
        public IActionResult AllDeleteInvestment(int InvestmentId)
        {
            try
            {
                var invesetment = _context.investments.Single(i => i.Id == InvestmentId);
                _context.investments.Remove(invesetment);
                _context.SaveChanges();
                return NoContent();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
