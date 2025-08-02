using Customer.Application.DTOs;
using Customer.Domain.Entities;

namespace Customer.Application.Extensions
{
    public static class UserExtensions
    {
        public static User UserDTOToEntity(this UserDTO dto)
        {
            return new User
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,      
                MensalIncome = dto.MensalIncome
            };
        }

        public static User CreateUserDTOToEntity(this CreateUserDTO dto)
        {
            return new User
            {
                Name = dto.Name,
                Email = dto.Email,
                MensalIncome = dto.MensalRent
            };
        }

        public static UserDTO ToUserDTO(this User entity)
        {
            return new UserDTO(entity);
        }
    }
}
