using Business_Back;
using Business_Back.Interface.BaseModelBusiness;
using Entity_Back;
using Microsoft.AspNetCore.Mvc;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Medical
{
    public class SheduleController : ControllerGeneric<SheduleCreateDto, SheduleEditDto, SheduleListDto>
    {
        private readonly ISheduleBusiness _sheduleBusiness;
        public SheduleController(
            IBaseModelBusiness<SheduleCreateDto, SheduleEditDto, SheduleListDto> service,
            ILogger<SheduleController> logger, ISheduleBusiness sheduleBusiness)
            : base(service, logger)
        {
            _sheduleBusiness = sheduleBusiness;
        }


        
        [HttpGet("listShedule/{id:int}")]
        [ProducesResponseType(typeof(IEnumerable<SheduleListDto>), 200)]
        public async Task<ActionResult<IEnumerable<SheduleListDto>>> GetSheduleByDoctor(int id)
        {
            try
            {
                var data = await _sheduleBusiness.GetSheduleByDoctor(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el horario con  {DoctorId}", id);
                return StatusCode(500, "Ocurrió un error al procesar la solicitud.");
            }
        }
    }
}
