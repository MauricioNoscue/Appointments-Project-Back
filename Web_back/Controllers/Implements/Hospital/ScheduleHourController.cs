using Business_Back;
using Business_Back.Interface.BaseModelBusiness;
using Entity_Back;
using Microsoft.AspNetCore.Mvc;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Medical
{
    public class ScheduleHourController : ControllerGeneric<ScheduleHourCreateDto, ScheduleHourEditDto, ScheduleHourListDto>
    {
        private readonly IScheduleHourBusiness _business;
        public ScheduleHourController(
            IBaseModelBusiness<ScheduleHourCreateDto, ScheduleHourEditDto, ScheduleHourListDto> service,
            ILogger<ScheduleHourController> logger, IScheduleHourBusiness business)
            : base(service, logger)
        {
            _business = business;
        }


        [HttpGet("GetByIdShedule/{id}")]
        public async Task<ActionResult<ScheduleHourListDto?>> GetByIdShedule(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El id debe ser mayor que cero.");
                }
                var result = await _business.GetByDateAndSheduleAsync(id);
                if (result == null)
                {
                    return NotFound($"No se encontró el horario con el ID {id}.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el horario por ID {Id}", id);
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        }
}
