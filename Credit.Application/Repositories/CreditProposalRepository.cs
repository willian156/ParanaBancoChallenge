using Credit.Domain.Entities;
using Credit.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit.Application.Repositories
{
    public class CreditProposalRepository : ICreditProposalRepository
    {
        private readonly DataContext _context;

        public CreditProposalRepository(DataContext context) 
        {
            context = _context;
        }

        public async Task<CreditProposalDTO?> GetCreditProposal(Guid id)
        {
            var creditProposal = await _context.CreditProposals.FindAsync(id);

            if (creditProposal == null)
            {
                return null;
            }
        }
    }
}
