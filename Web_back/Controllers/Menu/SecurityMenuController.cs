using Business_Back.Interface.IBusinessModel.Menu;
using Entity_Back.Dto.SecurityDto.Menu;
using Microsoft.AspNetCore.Mvc;

namespace Web_back.Controllers.Menu
{
    [ApiController]
    [Route("api/security")]
    [Produces("application/json")]

    public sealed class SecurityMenuController : ControllerBase
    {
        private readonly IMenuBusiness _menuBusiness;

        public SecurityMenuController(IMenuBusiness menuBusiness)
        {
            _menuBusiness = menuBusiness;
        }

        /// <summary>
        /// Devuelve el menú de navegación dinámico según el rol
        /// </summary>
        /// <param name="roleId">Id del rol</param>
        [HttpGet("menu")]
        public async Task<ActionResult<List<MenuItemDto>>> GetMenu([FromQuery] int roleId, CancellationToken ct)
        {
            if (roleId <= 0)
                return BadRequest("roleId es requerido");

            var menu = await _menuBusiness.GetMenuByRoleAsync(roleId, ct);

            return Ok(menu);
        }
    }
}
