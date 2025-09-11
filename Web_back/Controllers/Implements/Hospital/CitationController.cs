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

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<CitationListDto>>> GetList()
        {
            var data = await _biz.GetAllForListAsync();
            return Ok(data);
        }
    }
}
