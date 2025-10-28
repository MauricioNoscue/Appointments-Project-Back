using Business_Back.Interface.Socket;
using Entity_Back.Dto.Websocket.Requests;
using Entity_Back.Dto.Websocket;
using Entity_Back.Models.SecurityModels;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Web_back.Hub
{
    [ApiController]
    [Route("api/appointment-locks")]
    [Authorize] 
    public sealed class AppointmentLocksController : ControllerBase
    {
        private readonly IAppointmentOrchestrator _app;
        public AppointmentLocksController(IAppointmentOrchestrator app) => _app = app;

        private string GetUserId()
        {
            return User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
                ?? User.FindFirst("sub")?.Value
                ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? throw new InvalidOperationException("No user id in token");
        }

        [HttpPost("lock")]
        public async Task<ActionResult<SlotLockResponse>> Lock([FromBody] SlotLockRequest req, CancellationToken ct)
        {
            var userId = GetUserId();
            return await _app.TryLockAsync(req, userId, ct);
        }

        [HttpPost("unlock")]
        public async Task<ActionResult<SlotUnlockResponse>> Unlock([FromBody] SlotUnlockRequest req, CancellationToken ct)
        {
            var userId = GetUserId();
            return await _app.TryUnlockAsync(req, userId, ct);
        }

        [HttpPost("confirm")]
        public async Task<ActionResult> Confirm([FromBody] SlotKey slot, CancellationToken ct)
        {
            var userId = int.Parse(GetUserId());
            var (ok, id, reason) = await _app.ConfirmAsync(slot, userId, ct);
            if (!ok) return Conflict(new { message = reason });
            return Ok(new { citationId = id });
        }
    }
}
