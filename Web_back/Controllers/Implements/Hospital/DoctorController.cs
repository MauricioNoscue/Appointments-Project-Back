using Business_Back;
using Business_Back.Interface.BaseModelBusiness;
using Entity_Back;
using Microsoft.AspNetCore.Mvc;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Hospital
{
    public class DoctorController : ControllerGeneric<DoctorCreateDto, DoctorEditDto, DoctorListDto>
    {
        public readonly IDoctorBusiness _business;
        public DoctorController(
            IBaseModelBusiness<DoctorCreateDto, DoctorEditDto, DoctorListDto> service,
            ILogger<DoctorController> logger, IDoctorBusiness businness)
            : base(service, logger)
        {
            _business = businness;
        }

        [HttpGet("GetByIdDoctor/{id}")]
        public async Task<IActionResult> GetByIdDoctor(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El id debe ser mayor que cero.");
                }

                var result = await _business.GetDoctorWithPersonById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el doctor por PersonId {Id}", id);
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("GetAllDoctors")]
        public async Task<IActionResult> GetAllDoctors()
        {
            try
            {
                var result = await _business.GetAllDoctorWithPerson();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los doctores");
                return StatusCode(500, "Error interno del servidor.");
            }
        }
    }
}
