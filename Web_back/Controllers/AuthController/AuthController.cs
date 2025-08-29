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
                // Comentario: usa tu AuthService para validar credenciales y emitir tokens
                var result = await _authService.LoginWithTokensAsync(
                    request.Email,
                    request.Password,
                    HttpContext.Connection.RemoteIpAddress?.ToString()
                );

                if (result == null)
                    return Unauthorized("Credenciales inválidas.");

                return Ok(result); // { accessToken, refreshToken, expiresAtUtc }
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



    }
}
