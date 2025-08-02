using Customer.Domain.Entities;


namespace Customer.Application.Events
{
    public record UserCreatedEvent(Guid Id, string Name, string Email, decimal MensalIncome);
}