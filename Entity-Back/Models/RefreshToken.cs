using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models.SecurityModels;

namespace Entity_Back.Models
{
    public class RefreshToken
    {
        public int Id { get; set; }

        // Relación con User
        public int UserId { get; set; }
        public User User { get; set; } = default!;

        // Token aleatorio (puedes guardarlo plano o en hash; plano es más simple)
        public string Token { get; set; } = default!;

        // Control de ciclo de vida
        public DateTime ExpiresAtUtc { get; set; }         // ← expiración
        public DateTime CreatedAtUtc { get; set; }         // ← cuándo se emitió
        public string? CreatedByIp { get; set; }           // ← opcional

        public DateTime? RevokedAtUtc { get; set; }        // ← revocado manualmente
        public string? RevokedByIp { get; set; }           // ← opcional
        public string? ReplacedByToken { get; set; }       // ← rotación

        // Conveniencia
        public bool IsActive => RevokedAtUtc == null && DateTime.UtcNow < ExpiresAtUtc;
    }

}
