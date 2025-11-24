using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.Auth
{
    public class VerifyTwoFactorDto
    {
        public int UserId { get; set; }
        public string Code { get; set; }
    }

}
