using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.SignalR;

namespace Web_back.Extension
{
    public sealed class SubUserIdProvider : IUserIdProvider
    {
        public string? GetUserId(HubConnectionContext connection)
        {
            return connection.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
        }
    }
}
