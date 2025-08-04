using Card.Application.DTOs;
using Card.Domain.Entities;

namespace Card.Application.Extensions
{
    public static class CardProposalExtensions
    {
        public static CardProposal DtoToEntity(this CardProposalDTO dto)
        {
            return new CardProposal()
            {
                Id = dto.Id,
                UserId = dto.UserId,
                CreditProposalId = dto.CreditProposalId,
                CardType = dto.CardType
            };
        }

        public static CardProposalDTO EntityToDto(this CardProposal ent)
        {
            return new CardProposalDTO()
            {
                Id = ent.Id,
                UserId = ent.UserId,
                CreditProposalId = ent.CreditProposalId,
                CardType = ent.CardType
            };
        }
    }
}
