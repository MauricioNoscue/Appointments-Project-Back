using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models;

namespace Data_Back.Interface.Refresh
{

    public interface IRefreshTokenData
    {
        Task<RefreshToken> CreateAsync(int userId, TimeSpan ttl, string? ip);
        Task<RefreshToken?> GetActiveByTokenAsync(string token);
        Task SaveChangesAsync();
    }
}
