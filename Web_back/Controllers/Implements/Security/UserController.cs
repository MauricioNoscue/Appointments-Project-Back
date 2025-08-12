using Business_Back.Implements.ModelBusinessImplements.Security;
using Business_Back.Interface.BaseModelBusiness;
using Business_Back.Interface.IBusinessModel.Security;
using Entity_Back.Dto.SecurityDto.UserDto;
using Microsoft.AspNetCore.Mvc;
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

    }
}
