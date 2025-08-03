using Credit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit.Application.Extensions
{
    public static class CreditProposalExtensions
    {
        public static CreditProposal DtoToEntity(CreditProposalDTO dto)
        {
            return new CreditProposal()
            {
                Id = dto.Id,
                Proposal = dto.Proposal,
                UserId = dto.UserId,
                User = dto.User
            };
        }

        public static CreditProposalDTO EntityToDto(CreditProposal ent)
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
