using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Data_Back.Interface.Refresh;
using Entity_Back.Context;
using Entity_Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Data_Back.Implements.ModelDataImplement.Refresh
{

    public class RefreshTokenData : IRefreshTokenData
    {
        private readonly ApplicationDbContext _context;

        public RefreshTokenData(ApplicationDbContext context) => _context = context;

        // Comentario: crea y persiste un refresh token aleatorio
        public async Task<RefreshToken> CreateAsync(int userId, TimeSpan ttl, string? ip)
        {
            // Token aleatorio fuerte (Base64Url)
            var bytes = RandomNumberGenerator.GetBytes(64);
            var token = Convert.ToBase64String(bytes)
                .Replace("+", "-").Replace("/", "_").Replace("=", "");

            var entity = new RefreshToken
            {
                UserId = userId,
                Token = token,
                CreatedAtUtc = DateTime.UtcNow,
                ExpiresAtUtc = DateTime.UtcNow.Add(ttl),
                CreatedByIp = ip
            };

            _context.Set<RefreshToken>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        // Comentario: obtiene si está activo (no revocado y no expirado)
        public async Task<RefreshToken?> GetActiveByTokenAsync(string token)
        {
            return await _context.Set<RefreshToken>()
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.Token == token && r.RevokedAtUtc == null && r.ExpiresAtUtc > DateTime.UtcNow);
        }

        public Task SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
