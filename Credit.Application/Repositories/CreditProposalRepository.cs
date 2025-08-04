using Credit.Infrastructure.Data;
using Credit.Application.Extensions;
using Credit.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Credit.Application.DTOs;

namespace Credit.Application.Repositories
{
    public class CreditProposalRepository : ICreditProposalRepository
    {
        private readonly DataContext _context;

        public CreditProposalRepository(DataContext context) 
        {
            _context = context;
        }

        public async Task<CreditProposalDTO?> GetCreditProposal(Guid id)
        {
            var creditProposal = await _context.CreditProposals.FirstOrDefaultAsync(x => x.Id == id);

            if (creditProposal == null)
            {
                return null;
            }

            var proposalDTO = creditProposal.EntityToDto();

            return proposalDTO;
        }

        public async Task<CreditProposalDTO> PostCreditProposal(UserDTO usr)
        {
            var genCredit = CalculateLimit(usr.MensalIncome);

            var creditProposal = new CreditProposalDTO()
            {
                Proposal = genCredit,
                UserId = usr.Id
            };

            var proposal = _context.CreditProposals.Add(creditProposal.DtoToEntity());
            await _context.SaveChangesAsync();

            return proposal.Entity.EntityToDto();
        }

        decimal CalculateLimit(decimal MensalIncome)
        {
            if (MensalIncome < 1000)
                return 0;
            else if (MensalIncome < 2000)
                return MensalIncome * 0.3M;
            else if (MensalIncome < 5000)
                return MensalIncome * 0.5M;
            else
                return MensalIncome * 0.8M;
        }
    }
}
