using Microsoft.AspNetCore.Mvc;
using Card.Domain.Entities;
using Card.Application.Interfaces;

namespace Card.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardProposalsController : ControllerBase
    {
        private readonly ICardRepository _repository;

        public CardProposalsController(ICardRepository repository)
        {
            _repository = repository;
        }

         // GET: api/CardProposals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CardProposal>> GetCardProposal(Guid id)
        {
            var cardProp = _repository.GetCardProposal(id);

            if(cardProp == null)
            {
                return NotFound();
            }

            return Ok(cardProp);
        }
    }
}
