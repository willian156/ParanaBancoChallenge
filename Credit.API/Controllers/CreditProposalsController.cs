using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Credit.Domain.Entities;
using Credit.Infrastructure.Data;
using Credit.Application.Interfaces;

namespace Credit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditProposalsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ICreditProposalRepository _repository;

        public CreditProposalsController(DataContext context, ICreditProposalRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        // GET: api/CreditProposals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CreditProposalDTO>> GetCreditProposal(Guid id)
        {
            var creditProposal = await _repository.GetCreditProposal(id);

            if (creditProposal == null) 
            {
                return NotFound();
            }

            return Ok(creditProposal);
        }
    }
}
