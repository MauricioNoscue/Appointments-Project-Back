using Business_Back.Interface.BaseModelBusiness;
using Entity_Back.Context;
using Entity_Back.Dto.Notification;
using Entity_Back.Models.Notification;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.notification
{
    [ApiController]
    [Route("api/[controller]")] // → api/notification/...
    public class NotificationController
        : ControllerGeneric<NotificationCreateDto, NotificationEditDto, NotificationListDto>
    {
        public NotificationController(
            IBaseModelBusiness<NotificationCreateDto, NotificationEditDto, NotificationListDto> service,
            ILogger<NotificationController> logger
        ) : base(service, logger) { }

   
        [HttpPatch("{id:int}/state")]
        public async Task<IActionResult> UpdateState(
            int id,
            [FromBody] NotificationStateDto dto,
            [FromServices] ApplicationDbContext context)
        {
            // Stub con la PK
            var stub = new Notification { Id = id };

            // Adjuntar sin cargar toda la entidad
            context.Attach(stub);

            // Cambiar solo la propiedad requerida
            stub.StateNotification = dto.StateNotification;

            // Marcar SOLO StateNotification como modificada
            context.Entry(stub).Property(x => x.StateNotification).IsModified = true;

            // (No llames context.Update(stub); eso marca TODO)

            var rows = await context.SaveChangesAsync();
            if (rows == 0) return NotFound();

            return NoContent();
        }
    }

    // Puedes dejar este DTO al final del archivo
    public class NotificationStateDto
    {
        public bool StateNotification { get; set; }
    }
}
