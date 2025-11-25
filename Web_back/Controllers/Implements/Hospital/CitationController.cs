using Business_Back;
using Business_Back.Interface.BaseModelBusiness;
using Entity_Back;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Hospital
{
    /// <summary>
    /// Controlador para gestionar las citas médicas.
    /// </summary>
    public class CitationController : ControllerGeneric<CitationCreateDto, CitationEditDto, CitationListDto>
    {
        private readonly ICitationsBusiness _biz;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="CitationController"/>.
        /// </summary>
        /// <param name="service">Servicio base para operaciones CRUD.</param>
        /// <param name="biz">Servicio de negocio específico para citas.</param>
        /// <param name="logger">Logger para la clase.</param>
        public CitationController(IBaseModelBusiness<CitationCreateDto, CitationEditDto, CitationListDto> service,
                                  ICitationsBusiness biz,
                                  ILogger<CitationController> logger)
            : base(service, logger)
        {
            _biz = biz;
        }

        /// <summary>
        /// Obtiene la lista de citas para un usuario específico.
        /// Maneja excepciones y retorna un error 500 si ocurre una excepción.
        /// </summary>
        /// <param name="UserId">ID del usuario.</param>
        /// <returns>Lista de citas del usuario.</returns>
        /// <response code="200">Devuelve la lista de citas.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpGet("list/{UserId:int}")]
        [ProducesResponseType(typeof(IEnumerable<CitationListDto>), 200)]
        public async Task<ActionResult<IEnumerable<CitationListDto>>> GetList(int UserId)
        {
            try
            {
                var data = await _biz.GetAllForListAsync(UserId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la lista de citas para el usuario con ID {UserId}", UserId);
                return StatusCode(500, "Ocurrió un error al procesar la solicitud.");
            }
        }

        /// <summary>
        /// Obtiene la lista de citas para un doctor específico.
        /// Maneja excepciones y retorna un error 500 si ocurre una excepción.
        /// </summary>
        /// <param name="id">ID del doctor.</param>
        /// <returns>Lista de citas del doctor.</returns>
        /// <response code="200">Devuelve la lista de citas.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpGet("listDoctor/{id:int}")]
        [ProducesResponseType(typeof(IEnumerable<CitationListDto>), 200)]
        public async Task<ActionResult<IEnumerable<CitationListDto>>> GetCitationsByDoctor(int id, DateTime date)
        {
            try
            {
                var data = await _biz.GetCitationsByDoctor(id, date);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la lista de citas para el doctor con ID {DoctorId}", id);
                return StatusCode(500, "Ocurrió un error al procesar la solicitud.");
            }
        }
    }
}
