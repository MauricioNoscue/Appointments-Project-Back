using Business_Back.Services;
using Entity_Back.Dto.Auth;
using Microsoft.AspNetCore.Mvc;
using Utilities_Back.Exceptions;

namespace Web_back.Controllers.AuthController
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly JWTService _jwtService;

        public AuthController(AuthService authService, JWTService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;
        }


        [HttpPost("login")]
        [ProducesResponseType(typeof(AuthResultDto), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            try
            {
                // 1️⃣ Primero intentamos 2FA
                var twoFactorResult = await _authService.LoginWithTwoFactorAsync(
                    request.Email,
                    request.Password
                );

                if (twoFactorResult == null)
                    return Unauthorized("Credenciales inválidas.");

                // Si requiere 2FA → enviar respuesta al front
                if (twoFactorResult.RequiresTwoFactor)
                    return Ok(twoFactorResult);

                // 2️⃣ Si no requiere 2FA → login normal con tokens
                var tokens = await _authService.LoginWithTokensAsync(
                    request.Email,
                    request.Password,
                    HttpContext.Connection.RemoteIpAddress?.ToString()
                );

                if (tokens == null)
                    return Unauthorized("Credenciales inválidas.");

                return Ok(tokens);
            }
            catch (BusinessException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpPost("refresh")]
        [ProducesResponseType(typeof(AuthResultDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequestDto dto)
        {
            try
            {
                // Comentario: rota el refresh token y emite un nuevo par de tokens
                var result = await _authService.RefreshAsync(dto.RefreshToken, HttpContext.Connection.RemoteIpAddress?.ToString());
                if (result == null)
                    return BadRequest(new { message = "Invalid or expired refresh token." });

                return Ok(result); // { accessToken, refreshToken, expiresAtUtc }
            }
            catch (BusinessException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpPost("verify-2fa")]
        public async Task<IActionResult> VerifyTwoFactor([FromBody] VerifyTwoFactorDto dto)
        {
            var result = await _authService.VerifyTwoFactorAsync(dto.UserId, dto.Code);

            if (result == null)
                return Unauthorized("Código inválido o expirado.");

            return Ok(result);  // ahora sí devuelves tokens
        }



    }
}
