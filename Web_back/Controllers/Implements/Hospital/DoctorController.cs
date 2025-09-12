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

        /// <summary>
        /// Obtiene todas las citas asignadas a un doctor específico
        /// Endpoint: GET /api/Doctor/{id}/citas
        /// </summary>
        /// <param name="id">ID del doctor</param>
        /// <returns>Lista de citas del doctor</returns>
        [HttpGet("{id}/citas")]
        public async Task<IActionResult> GetCitationsByDoctor(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El id del doctor debe ser mayor que cero.");
                }

                var citations = await _business.GetCitationsByDoctorId(id);
                return Ok(citations);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener las citas del doctor {DoctorId}", id);
                return StatusCode(500, "Error interno del servidor.");
            }
        }
    }
}
