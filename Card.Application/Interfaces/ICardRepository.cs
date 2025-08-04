using Card.Application.DTOs;
using Card.Applications.DTOs;

namespace Card.Application.Interfaces
{
    public interface ICardRepository
    {
        Task<CardProposalDTO> GetCardProposal(Guid id);
        void PostCardProposal(CreditProposalDTO credProp);
    }
}
