using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Utilities_Back.Helper
{
    // Comentario: extensión para obtener el UserId del token JWT
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            var claim = user.FindFirst("uid")
             ?? user.FindFirst(ClaimTypes.NameIdentifier)
             ?? user.FindFirst("sub");

            if (claim == null)
                throw new UnauthorizedAccessException("The token does not contain the UID claim.");

            return int.Parse(claim.Value);
        }
    }

}
