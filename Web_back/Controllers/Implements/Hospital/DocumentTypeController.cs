using Business_Back.Interface.BaseModelBusiness;
using Entity_Back;
using Microsoft.AspNetCore.Mvc;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.Hospital
{
    public class DocumentTypeController : ControllerGeneric<DocumentTypeCreatedDto, DocumentTypeEditDto, DocumentTypeListDto>
    {
        public DocumentTypeController(IBaseModelBusiness<DocumentTypeCreatedDto, DocumentTypeEditDto, DocumentTypeListDto> service,
                            ILogger<DocumentTypeController> logger)
            : base(service, logger)
        {
        }
    }
}