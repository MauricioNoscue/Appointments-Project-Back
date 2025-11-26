using Business_Back.Interface;
using Business_Back.Interface.IBusinessModel.Security;
using Entity_Back.Dto.SecurityDto.PersonDto;
using Entity_Back.Dto.SecurityDto.UserDto;
using Microsoft.AspNetCore.Mvc;
using Utilities_Back.Exceptions;

namespace Web_back.Controllers.Implements
{

    [Route("api/[controller]")]
    [ApiController]
    public class PersonUserController : ControllerBase
    {
        private readonly IPersonUserCoreService _personBusiness;

        public PersonUserController(IPersonUserCoreService personBusiness)
        {
            _personBusiness = personBusiness;
        }

        /// <summary>
        /// Crea una Persona y su Usuario asociado en una sola operación.
        /// </summary>
        [HttpPost("create-person-user")]
        [ProducesResponseType(typeof(UserListDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreatePersonUser([FromBody] PersonUserCreateDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _personBusiness.CreatePersonAndUserAsync(dto);

                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (BusinessException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error inesperado.", detail = ex.Message });
            }
        }
    }
}
