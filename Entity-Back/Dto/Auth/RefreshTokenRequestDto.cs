using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.Auth
{
    // Comentario: usar para solicitar refresh
    public sealed class RefreshTokenRequestDto
    {
        public string RefreshToken { get; set; } = default!;
    }
}
