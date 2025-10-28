using Business_Back.Interface.BaseModelBusiness;
using Business_Back.Interface.IBusinessModel.Notification;
using Entity_Back.Context;
using Entity_Back.Dto.Notification;
using Entity_Back.Models.Notification;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_back.Controllers.ControllerModel;

namespace Web_back.Controllers.Implements.notification
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController: ControllerGeneric<NotificationCreateDto, NotificationEditDto, NotificationListDto>
    {

        private readonly INotificationBusiness _notificationBusiness;
        public NotificationController(
            IBaseModelBusiness<NotificationCreateDto, NotificationEditDto, NotificationListDto> service,
            ILogger<NotificationController> logger, INotificationBusiness notificationBusiness
        ) : base(service, logger)
        {

            _notificationBusiness = notificationBusiness;

        }


        [HttpPatch("{id:int}/mark-read")]
        public async Task<IActionResult> UpdateState(int id)
        {
            try
            {
                bool response = await _notificationBusiness.UpdateStatusNotification(id);

                if (!response)
                {
                    return NotFound(new { message = $"No se encontró la notificación con ID {id}." });
                }
                return Ok(new { message = "Estado de la notificación actualizado correctamente." });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(UpdateState)}: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });

            }
        }
    }
}
