using Customer.Application.DTOs;
using Customer.Application.Events;
using Customer.Application.Extensions;
using Customer.Application.Interfaces;
using Customer.Domain.Entities;
using Customer.Infrastructure.Data;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Customer.Application.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IPublishEndpoint _publishEndpoint;
        public UserRepository(DataContext context, IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _publishEndpoint = publishEndpoint;

        }

        public UserDTO GetUser(Guid id) 
        {
            var user = _context.Users
                        .Where(u => EF.Property<bool>(u, "IsDeleted") == false && u.Id == id)
                        .Select(u => new UserDTO(u))
                        .FirstOrDefault();

            return user;
        }

        public async Task<Guid?> PostUser(CreateUserDTO user) 
        {

            var exists = await _context.Users
                .Where(u => EF.Property<bool>(u, "IsDeleted") == false)
                .AnyAsync(u => u.Email == user.Email);

            if (exists)
            {
                return null;
            }

            var newUsr = _context.Users.Add(user.CreateUserDTOToEntity());
            await _context.SaveChangesAsync();

            var createdUsrDTO = newUsr.Entity.ToUserDTO();

            var userEvent = new UserCreatedEvent(createdUsrDTO.Id, createdUsrDTO.Name, createdUsrDTO.Email, createdUsrDTO.MensalIncome);
            await _publishEndpoint.Publish(userEvent);

            return newUsr.Entity.Id;

        }

        public async Task DeleteUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return;

            _context.Entry(user).Property("IsDeleted").CurrentValue = true;
            await _context.SaveChangesAsync();
        }

        private bool UserExists(Guid id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
