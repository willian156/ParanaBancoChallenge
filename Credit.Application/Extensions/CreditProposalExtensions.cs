using Credit.Application.DTOs;
using Credit.Domain.Entities;

namespace Credit.Application.Extensions
{
    public static class CreditProposalExtensions
    {
        public static CreditProposal DtoToEntity(this CreditProposalDTO dto)
        {
            return new CreditProposal()
            {
                Id = dto.Id,
                Proposal = dto.Proposal,
                UserId = dto.UserId,
                User = dto.User
            };
        }

        public static CreditProposalDTO EntityToDto(this CreditProposal ent)
        {
            return new CreditProposalDTO()
            {
                Id = ent.Id,
                Proposal = ent.Proposal,
                UserId = ent.UserId,
                User = ent.User
            };
        }
    }
}
