using Business_Back.Interface.IBusinessModel.Hospital;
using Entity_Back.Dto.HospitalDto.RelatedPerson;
using Microsoft.AspNetCore.Mvc;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Hospital
{
    [ApiController]
    [Route("api/[controller]")] // ← prefijo para todos los métodos
    public class RelatedPersonController
        : ControllerGeneric<RelatedPersonCreatedDto, RelatedPersonEditDto, RelatedPersonListDto>
    {
        private readonly IRelatedPersonBusiness _related;

        public RelatedPersonController(
            IRelatedPersonBusiness service,
            ILogger<RelatedPersonController> logger
        ) : base(service, logger)
        {
            _related = service;
        }

        // GET /api/RelatedPerson/by-person/{personId}
        [HttpGet("by-person/{personId:int}")]
        public async Task<IActionResult> GetByPerson(int personId)
        {
            if (personId <= 0)
                return BadRequest(new { message = "El PersonId debe ser mayor que cero." });

            var result = await _related.GetByPersonAsync(personId);
            return Ok(result);
        }
    }
}
