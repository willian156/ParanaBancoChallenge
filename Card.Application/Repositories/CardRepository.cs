using Card.Application.DTOs;
using Card.Application.Extensions;
using Card.Application.Interfaces;
using Card.Applications.DTOs;
using Card.Domain.Entities;
using Card.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Card.Application.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly DataContext _context;
        public CardRepository(DataContext context) 
        {
            _context = context;
        }

        public async Task<CardProposalDTO> GetCardProposal(Guid id)
        {
            var cardProposal = await _context.Cards.FirstOrDefaultAsync(x =>x.Id == id);

            if (cardProposal == null)
            {
                return null;
            }

            return cardProposal.EntityToDto();
        }

        public void PostCardProposal(CreditProposalDTO credProp)
        {
            var genCard = GenCard(credProp.Proposal);

            var cardProposal = new CardProposalDTO()
            {
                CardType = (CardType)genCard,
                UserId = credProp.UserId,
                CreditProposalId = credProp.Id
            };

            _context.Add(cardProposal.DtoToEntity());
            _context.SaveChanges();
        }



        public int GenCard(decimal proposal)
        {
            if (proposal == 0)
                return 0;

            if (proposal <= 1000)
                return 1;

            if (proposal <= 3000)
                return 2;
            if(proposal <= 5000)
                return 3;

            return 4;
        }
    }
}
