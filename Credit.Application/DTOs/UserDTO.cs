
using Credit.Domain.Entities;

namespace Credit.Application.DTOs
{
    public class UserDTO
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal MensalIncome { get; set; }

        public UserDTO() { }
        public UserDTO(User usr)
        {
            (Id, Name, Email, MensalIncome) = (usr.Id, usr.Name, usr.Email, usr.MensalIncome);
        }
    }
}
