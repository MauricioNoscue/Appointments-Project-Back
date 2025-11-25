using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.Auth
{
    public  class AuthResultDto
    {
        public string AccessToken { get; set; } = default!;
        public string RefreshToken { get; set; } = default!;
        public DateTime ExpiresAtUtc { get; set; }          // exp del access token

        public bool RequiresTwoFactor { get; set; }   // true cuando toca verificar el código

        // 👇 ÚNICO dato que necesitas devolver al front
        public int? UserId { get; set; }
        public bool IsBlocked { get; set; }
    }
}
