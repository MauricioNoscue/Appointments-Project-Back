using Business_Back.Interface.BaseModelBusiness;
using Entity_Back.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utilities_Back.Exceptions;

namespace Web_back.Controllers.ControllerModel
{

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ControllerGeneric<Dc,De,Dl> : ControllerBase where Dc : class where De : class where Dl : BaseModel
    {
        private readonly IBaseModelBusiness<Dc, De, Dl> _service;
        public readonly ILogger _logger;


        public ControllerGeneric(IBaseModelBusiness<Dc, De, Dl> service, ILogger logger)
        {
            _logger = logger;
            _service = service;
        }
       
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                var entity = await _service.GetAll();
                return Ok(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los Form");
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpGet("{id:int}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {

                var form = await _service.GetById(id);
                return Ok(form);

            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida para el form con ID:" + id);
                return BadRequest(new { Mesagge = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, "form no encontrado con ID: {form}", id);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al obtener form con ID: {module}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Create([FromBody] Dc dto)
        {
            try
            {
                var created = await _service.Save(dto);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);



            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida");
                return BadRequest(new { mesagge = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al crear el form");
                return StatusCode(500, new { mesagge = ex.Message });
            }
        }



        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Update([FromBody] De dto)
        {
            try
            {


                var updated = await _service.Update(dto);
                return Ok(updated);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida al actualizar ");
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, "module no encontrado con ID: {RolId}");
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al actualizar el module con ID: {RolId}");
                return StatusCode(500, new { message = ex.Message });
            }
        }



        [HttpDelete("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest(new { message = "El ID del  debe ser mayor que cero" });
                }

                //await _rolBusiness.DeletePermanentAsync(id);
                //await _service.DeleteAsyncStrategy(request.Id, request.Strategy);
                await _service.Delete(id);
                return Ok(new { message = "Rol eliminado correctamente" });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, "Rol no encontrado con ID: {RolId}", id);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al eliminar el rol con ID: {RolId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }




        [HttpPatch("logic/{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteLogical(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest(new { message = "El ID del  debe ser mayor que cero" });
                }

                //await _rolBusiness.DeletePermanentAsync(id);
                //await _service.DeleteAsyncStrategy(request.Id, request.Strategy);
                await _service.DeleteLogical(id);
                return Ok(new { message = "Rol eliminado correctamente" });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, "Rol no encontrado con ID: {RolId}", id);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al eliminar el rol con ID: {RolId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }


    }



}
