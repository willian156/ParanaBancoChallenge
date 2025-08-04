using Credit.Application.DTOs;
using Credit.Application.Interfaces;
using MassTransit;
using Shared.Contracts;

namespace Credit.Application.Consumers
{
    public class UserCreatedEventConsumer : IConsumer<UserCreatedEvent>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ICreditProposalRepository _repository;

        public UserCreatedEventConsumer(IPublishEndpoint publishEndpoint, ICreditProposalRepository repository)
        {
            _repository = repository;
            _publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<UserCreatedEvent> context)
        {
            var message = context.Message;

            var usrDTO = new UserDTO()
            {
                Id = message.Id,
                Name = message.Name,
                Email = message.Email,
                MensalIncome = message.MensalIncome
            };
            
            var creditProposal = await _repository.PostCreditProposal(usrDTO);
            
            await _publishEndpoint.Publish(new CreditProposalCreatedEvent
            {
                Id = creditProposal.Id,
                Proposal = creditProposal.Proposal,
                UserId = creditProposal.UserId
            });
        }
    }
}
