
using Business_Back.Services.Citation;
using Entity_Back;
using Microsoft.AspNetCore.Mvc;

namespace Web_back.Controllers.Implements
{

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CitationCoreController : ControllerBase
    {
        private readonly CitationCoreService _service;
        public CitationCoreController(CitationCoreService service)
        {
            _service = service;
        }


        [HttpGet("core/{id}")]
        public async Task<ActionResult<ScheduleHourListDto?>> GetByIdShedule(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El id debe ser mayor que cero.");
                }
                var result = await _service.GetAvailableTimeBlocksByTypeCitationIdAsync(id);
                if (result == null)
                {
                    return NotFound($"No se encontró el horario con el ID {id}.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el horario por ID {id}: {ex.Message}", ex);
            }
        }

    }
}
