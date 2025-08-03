using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit.Domain.Entities
{
    public class CreditProposal
    {
        public Guid Id { get; set; }
        public decimal Proposal { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
