using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Dto.SecurityDto.PersonDto;

namespace Entity_Back.Dto.SecurityDto.UserDto
{
    public  class UserCreatedDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public PersonCreatedDto Person { get; set; }
    }
}
