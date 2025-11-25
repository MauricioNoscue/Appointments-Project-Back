using Business_Back.Implements.ModelBusinessImplements.Security;
using Business_Back.Interface.BaseModelBusiness;
using Business_Back.Interface.IBusinessModel.Security;
using Entity_Back.Dto.SecurityDto.UserDto;
using Entity_Back.Dto.Status;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utilities_Back.Exceptions;
using Utilities_Back.Helper;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Security
{
    public class UserController :ControllerGeneric<UserCreatedDto, UserEditDto, UserListDto>
    {
        private readonly IUserBusiness _service;
        public UserController(IUserBusiness userBusiness, ILogger<UserController> logger)
      : base(userBusiness, logger)
        {
            _service = userBusiness;
        }

        [HttpGet("{id}/userDetail")]
        public async Task<IActionResult> GetUserDetail(int id)
        {
            var result = await _service.GetUserDetailAsync(id);
            if (result == null)
                return NotFound("Usuario no encontrado");

            return Ok(result);
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequestDto dto)
        {
            try
            {
                var token = await _service.RequestPasswordResetAsync(dto.Email);
                return Ok(new
                {
                    message = "Si el correo electrónico existe, se generó un token de restablecimiento.",
                    token
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en forgot-password");
                return StatusCode(500, new { mesagge = ex.Message });
            }
        }


        [HttpPost("reset-password")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequestDto dto)
        {
            try
            {
                // Comentario: validar token y actualizar contraseña hasheada
                var ok = await _service.ResetPasswordAsync(dto.Email, dto.Token, dto.NewPassword);
                if (!ok)
                    return BadRequest(new { mesagge = "Invalid or expired token." });

                return Ok(new { message = "Password updated successfully." });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida en reset-password");
                return BadRequest(new { mesagge = ex.Message });
            }
            catch (BusinessException ex)
            {
                _logger.LogError(ex, "Error en reset-password");
                return StatusCode(500, new { mesagge = ex.Message });
            }
        }


        [Authorize]
        [HttpPatch("Rescheduling")]
        public async Task<IActionResult> ToggleReschedulingAsync()
        {
            try
            {
                int userId = User.GetUserId();
                var status = await _service.ToggleReschedulingAsync(userId);

                return Ok(new { message = "Status updated successfully." });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (BusinessException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Internal error in update status .");
                return StatusCode(500, new { message = "Internal server error." });
            }
        }



    }
}
