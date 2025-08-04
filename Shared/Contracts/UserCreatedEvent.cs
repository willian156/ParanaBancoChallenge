namespace Shared.Contracts
{
    public record UserCreatedEvent(Guid Id, string Name, string Email, decimal MensalIncome);
}