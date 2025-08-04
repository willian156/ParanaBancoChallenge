using Credit.Application.DTOs;

namespace Credit.Application.Interfaces
{
    public interface ICreditProposalRepository
    {
        Task<CreditProposalDTO?> GetCreditProposal(Guid id);
        Task<CreditProposalDTO> PostCreditProposal(UserDTO usr);
    }
}
