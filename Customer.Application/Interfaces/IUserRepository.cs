using Customer.Application.DTOs;
using Customer.Domain.Entities;

namespace Customer.Application.Interfaces
{
    public interface IUserRepository
    {
        UserDTO GetUser(Guid id);
        Task<Guid?> PostUser(CreateUserDTO user);
        Task DeleteUser(Guid id);
    }
}
