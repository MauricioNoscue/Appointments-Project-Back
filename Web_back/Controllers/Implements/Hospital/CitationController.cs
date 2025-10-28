using Business_Back;
using Business_Back.Interface.BaseModelBusiness;
using Entity_Back;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Hospital
{
    public class CitationController : ControllerGeneric<CitationCreateDto, CitationEditDto, CitationListDto>
    {
        private readonly ICitationsBusiness _biz;

        public CitationController(IBaseModelBusiness<CitationCreateDto, CitationEditDto, CitationListDto> service,
                                  ICitationsBusiness biz,
                                  ILogger<CitationController> logger)
            : base(service, logger)
        {
            _biz = biz;
        }

        [HttpGet("list/{UserId:int}")]
        public async Task<ActionResult<IEnumerable<CitationListDto>>> GetList(int UserId)
        {
            var data = await _biz.GetAllForListAsync(UserId);
            return Ok(data);
        }
    }
}
