using Customer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.DTOs
{
    public class CreateUserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal MensalRent { get; set; }

        public CreateUserDTO() { }
        public CreateUserDTO(User usr)
        {
            ( Name, Email, MensalRent) = (usr.Name, usr.Email, usr.MensalIncome);
        }
    }
}
