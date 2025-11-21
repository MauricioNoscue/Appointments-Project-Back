using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.SecurityDto.UserDto
{
    public class UserDetailDto
    {
        public string FullName { get; set; }
        public string FullLastName { get; set; }
        public string Document { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateBorn { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Gender { get; set; }
        public string HealthRegime { get; set; }
        public List<string> Roles { get; set; }

        public bool Rescheduling { get; set; } = false;

    }
}
