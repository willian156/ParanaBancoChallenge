using Microsoft.AspNetCore.Mvc;
using Customer.Domain.Entities;
using Customer.Application.Interfaces;
using Customer.API.Models;
using Customer.Application.DTOs;

namespace Customer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(Guid id)
        {
            var user = _userRepository.GetUser(id);

            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUser(CreateUserDTO user)
        {
            var usrId = await _userRepository.PostUser(user);

            if (usrId == null)
            {
                return Conflict(new ErrorResponse()
                {
                    Message = "User already created with same e-mail!",
                    Details = new { user.Name, user.Email }
                });
            }

            return CreatedAtAction("GetUser", new { id = usrId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userRepository.DeleteUser(id);

            return Ok();
        }

        
    }
}
