using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Credit.Domain.Entities;
using Credit.Infrastructure.Data;

namespace Credit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditProposalsController : ControllerBase
    {
        private readonly DataContext _context;

        public CreditProposalsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/CreditProposals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CreditProposal>> GetCreditProposal(Guid id)
        {
            var creditProposal = await _context.CreditProposals.FindAsync(id);

            if (creditProposal == null)
            {
                return NotFound();
            }

            return creditProposal;
        }
    }
}
