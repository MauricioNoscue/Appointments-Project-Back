using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Dto.SecurityDto.PersonDto;
using Entity_Back.Models;

namespace Entity_Back.Dto.SecurityDto.UserDto
{
    public class UserListDto : BaseModel
    {
        //public PersonListDto Person {  get; set; }
        public int PersonId { get; set; }
        public string PersonName { get; set; }

        public string? Email { get; set; }
        public bool? Active { get; set; } = false;
        public string? CodePassword { get; set; }
        public int? RestrictionPoint { get; set; }

    }
}
