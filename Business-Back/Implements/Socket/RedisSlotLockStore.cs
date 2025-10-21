using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Business_Back.Interface.Socket;
using Entity_Back.Dto.Websocket;
using Microsoft.Extensions.Caching.Distributed;

namespace Business_Back.Implements.Socket
{
    public sealed class RedisSlotLockStore : ISlotLockStore
    {
        private readonly IDistributedCache _cache;
        public RedisSlotLockStore(IDistributedCache cache) => _cache = cache;

        private static string Key(SlotKey s)
            => $"slot:{s.ScheduleHourId}:{s.Date:yyyyMMdd}:{(int)s.TimeBlock.TotalSeconds}";

        private sealed class LockPayload
        {
            public string OwnerUserId { get; set; } = default!;
            public DateTime LockedUntil { get; set; }         
        }

        public async Task<(bool acquired, DateTime? lockedUntil, string? owner)>
            TryAcquireAsync(SlotKey slot, string userId, TimeSpan ttl, CancellationToken ct)
        {
            var key = Key(slot);
            var now = DateTime.UtcNow;
            var payload = new LockPayload
            {
                OwnerUserId = userId,
                LockedUntil = now.Add(ttl)
            };
            var json = JsonSerializer.Serialize(payload);

            // (ES): Verifica si existe un lock vigente; si expiró, se sobreescribe
            var existing = await _cache.GetStringAsync(key, ct);
            if (!string.IsNullOrEmpty(existing))
            {
                var current = JsonSerializer.Deserialize<LockPayload>(existing)!;
                if (current.LockedUntil <= now)
                {
                    await _cache.SetStringAsync(key, json, new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = ttl
                    }, ct);
                    return (true, payload.LockedUntil, userId);
                }
                return (false, current.LockedUntil, current.OwnerUserId);
            }

            await _cache.SetStringAsync(key, json, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = ttl
            }, ct);

            return (true, payload.LockedUntil, userId);
        }

        public async Task<(bool released, string? owner)> TryReleaseAsync(
            SlotKey slot, string userId, CancellationToken ct)
        {
            var key = Key(slot);
            var existing = await _cache.GetStringAsync(key, ct);
            if (string.IsNullOrEmpty(existing)) return (false, null);

            var current = JsonSerializer.Deserialize<LockPayload>(existing)!;
            if (current.OwnerUserId != userId) return (false, current.OwnerUserId);

            await _cache.RemoveAsync(key, ct);
            return (true, userId);
        }

        public async Task<(bool owned, DateTime? lockedUntil, string? owner)> CheckAsync(
            SlotKey slot, string userId, CancellationToken ct)
        {
            var key = Key(slot);
            var existing = await _cache.GetStringAsync(key, ct);
            if (string.IsNullOrEmpty(existing)) return (false, null, null);

            var current = JsonSerializer.Deserialize<LockPayload>(existing)!;
            var now = DateTime.UtcNow;
            if (current.LockedUntil <= now)
            {
                await _cache.RemoveAsync(key, ct);
                return (false, null, null);
            }

            return (current.OwnerUserId == userId, current.LockedUntil, current.OwnerUserId);
        }
    }
}
