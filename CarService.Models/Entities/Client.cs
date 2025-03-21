using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models.Entities
{
    public class Client
    {
        int ClientId { get; set; }
        string FirstName { get; set; } = null!;
        string LastName { get; set; } = null!;
        string PhoneNumber { get; set; } = null!;
        string Email { get; set; } = null!;
    }
}
