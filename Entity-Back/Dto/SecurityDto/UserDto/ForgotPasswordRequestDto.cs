using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.SecurityDto.UserDto
{
    public  class ForgotPasswordRequestDto
    {
        public string Email { get; set; } = default!;
    }
}
