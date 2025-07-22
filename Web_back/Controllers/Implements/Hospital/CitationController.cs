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
        public CitationController(IBaseModelBusiness<CitationCreateDto, CitationEditDto, CitationListDto> service,
                                    ILogger<CitationController> logger)
            : base(service, logger)
        {
        }
    }
}
