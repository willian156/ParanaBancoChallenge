using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card.Domain.Entities
{
    public class Card
    {
        public Guid Id { get; set; }
        public CardType CardType { get; set; }
        public Guid UserId { get; set; }
        public UserReadOnly User { get; set; }
        public Guid CreditProposalId { get; set; }
        public CreditProposalReadOnly CreditProposal { get; set; }
    }
}
