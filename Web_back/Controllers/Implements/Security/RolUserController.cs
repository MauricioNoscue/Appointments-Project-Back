using Business_Back.Implements.ModelBusinessImplements.Security;
using Business_Back.Interface.BaseModelBusiness;
using Business_Back.Interface.IBusinessModel.Security;
using Entity_Back.Dto.SecurityDto.RolUserDto;
using Entity_Back.Dto.SecurityDto.UserDto;
using Microsoft.AspNetCore.Mvc;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Security
{
    public class RolUserController : ControllerGeneric<RolUserCreatedDto, RolUserEditDto, RolUserList>
    {
        private readonly IRolUserBusiness _service;
        public RolUserController(IRolUserBusiness  service, ILogger<RolUserController> logger):
            base(service, logger) 
        {
            _service = service;
        }

        [HttpPut("update-roles")]
        public async Task<IActionResult> UpdateUserRoles([FromBody] UpdateUserRolesDto dto)
        {
            await _service.UpdateUserRolesAsync(dto);
            return Ok(new { message = "Roles actualizados correctamente." });
        }



        [HttpGet("{userId}/roles-permissions")]
        public async Task<IActionResult> GetUserRolesAndPermissions(int userId) 
        {
            var result = await _service.GetRolesAndPermissionsByUserIdAsync(userId);
            return Ok(result);
        }

        [HttpPost("assign-multiple")]
        public async Task<IActionResult> AssignMultipleRoles([FromBody] AssignRolesDto dto)
        {
            await _service.AssignRolesAsync(dto);
            return Ok(new { message = "Roles asignados correctamente." });
        }


    }
}
