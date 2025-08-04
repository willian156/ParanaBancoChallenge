using Card.Domain.Entities;

namespace Card.Applications.DTOs
{
    public class CreditProposalDTO
    {
        public Guid Id { get; set; }
        public decimal Proposal { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public CreditProposalDTO() { }
    }
}
