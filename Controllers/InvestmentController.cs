using Microsoft.AspNetCore.Mvc;
using Wallet.Services;

namespace Wallet.Controllers
{
    [ApiController]
    public class InvestmentController : ControllerBase
    {
        private readonly WalletContext _context;
        public InvestmentController(WalletContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult AllUserInvestment(int InvestmentTypeId)
        {
            try
            {
                // retrive the user and investtype 
                var user = _context.users.Single((u) => u.Id == 1);
                var investType = _context.investmentTypes.Single((i) => i.Id == InvestmentTypeId);
                // create the new investment 
                var newInvestment = _context.investments.Add(new Models.Investment
                {
                    InvestmentTypeId = InvestmentTypeId,
                    UserId = 1,
                    investmentType = investType,
                    user = user
                });
                return Ok(newInvestment);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }
        [HttpPost]
        public IActionResult CreateInvestment()
        {
            throw new NotImplementedException();
        }
        [HttpPut]
        public IActionResult UpdateInvestment()
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        public IActionResult AllDeleteInvestment()
        {
            throw new NotImplementedException();
        }

    }
}
