using Card.Domain.Entities;

namespace Card.Domain.Entities
{
    public class CreditProposal
    {
        public Guid Id { get; set; }
        public decimal Proposal { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
