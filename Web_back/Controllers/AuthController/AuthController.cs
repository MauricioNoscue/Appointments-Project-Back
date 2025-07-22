using Business_Back.Services;
using Entity_Back.Dto.Auth;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            // 1. Validar las credenciales usando el servicio de autenticación
            var user = await _authService.Login(request.Email, request.Password);

            // 2. Si no se encontró el usuario, retornar error 401
            if (user == null)
                return Unauthorized("Credenciales inválidas.");

            // 3. Obtener los roles asociados al usuario autenticado
            //var roles = await _rolUserResvice.GetRolesByUserId(user.Id);
            //var permissions = await _rolUserResvice.GetPermissionsByUserId(user.Id);
            // 4. Generar un token JWT con los datos del usuario
            var token = _jwtService.GenerateToken(user.Id.ToString(), user.Email);

            // 5. Retornar el token generado al frontend
            return Ok(new { token });
        }


    }
}
