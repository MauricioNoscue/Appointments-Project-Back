
using Business_Back.Services.Citation;
using Entity_Back;
using Entity_Back.Dto.HospitalDto.Citation;
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

        [HttpGet("core")]
        public async Task<ActionResult<List<TimeBlockEstado>>> GetAvailableBlocks( [FromQuery] int typeCitationId, [FromQuery] DateTime date, [FromQuery] bool incluirOcupados = false) 
        {
            try
            {
                if (typeCitationId <= 0)
                    return BadRequest("El tipo de cita debe ser mayor que cero.");

                var result = await _service.GetAvailableTimeBlocksByTypeCitationIdAsync(typeCitationId, date.Date, incluirOcupados);

                if (result == null || result.Count == 0)
                    return NotFound($"No hay bloques encontrados para el tipo de cita {typeCitationId} en {date:yyyy-MM-dd}.");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener bloques: {ex.Message}");
            }
        }



    }
}
