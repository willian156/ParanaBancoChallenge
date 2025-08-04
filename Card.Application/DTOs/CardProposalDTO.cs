using Card.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card.Application.DTOs
{
    public class CardProposalDTO
    {
        public Guid Id { get; set; }
        public CardType CardType { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid CreditProposalId { get; set; }
        public CreditProposal CreditProposal { get; set; }

        public CardProposalDTO() { }
    }
}
