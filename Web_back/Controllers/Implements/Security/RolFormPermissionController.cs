using Business_Back.Implements.ModelBusinessImplements.Security;
using Business_Back.Interface.BaseModelBusiness;
using Business_Back.Interface.IBusinessModel.Security;
using Entity_Back.Dto.SecurityDto.RolFormPermissionDto;
using Microsoft.AspNetCore.Mvc;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Security
{
    public class RolFormPermissionController : ControllerGeneric<RolFormPermissionCreatedDto, RolFormPermissionEditDto, RolFormPermissionListDto>
    {
        private readonly IRolFormPermissionBusiness _service;
        public RolFormPermissionController(IRolFormPermissionBusiness service,
                                           ILogger<RolFormPermissionController> logger)
            : base(service, logger)
        {
            _service = service;
        }


        [HttpPut("update-permissions")]
        public async Task<IActionResult> UpdatePermissions([FromBody] UpdateRolFormPermissionsDto dto)
        {
            await _service.UpdateRolFormPermissionsAsync(dto);
            return Ok(new { message = "Permisos actualizados correctamente." });
        }


        [HttpPost("assign")]
        public async Task<IActionResult> AssignPermissions([FromBody] AssignPermissionsDto dto)
        {
            await _service.AssignPermissionsAsync(dto);
            return Ok(new { message = "Permisos asignados correctamente." });
        }

    }

}
