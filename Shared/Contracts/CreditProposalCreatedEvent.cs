namespace Shared.Contracts
{
    public class CreditProposalCreatedEvent
    {
        public Guid Id { get; set; }
        public decimal Proposal { get; set; }
        public Guid UserId { get; set; }
    }
}
