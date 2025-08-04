using Card.Application.DTOs;
using Card.Application.Interfaces;
using Card.Applications.DTOs;
using MassTransit;
using Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card.Application.Consumers
{
    public class CreditProposalCreatedEventConsumer : IConsumer<CreditProposalCreatedEvent>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ICardRepository _repository;

        public CreditProposalCreatedEventConsumer(IPublishEndpoint publishEndpoint, ICardRepository repository)
        {
            _repository = repository;
            _publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<CreditProposalCreatedEvent> context)
        {
            var message = context.Message;

            var usrDTO = new CreditProposalDTO()
            {
                Id = message.Id,
                UserId = message.UserId,
                Proposal = message.Proposal

            };

            _repository.PostCardProposal(usrDTO);
            
        }
    }
}
