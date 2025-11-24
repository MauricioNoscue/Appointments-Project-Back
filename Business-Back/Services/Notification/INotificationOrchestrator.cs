using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Dto.Notification.SendEmail;

namespace Business_Back.Services.Notification
{
    public interface INotificationOrchestrator
    {
        Task SendAsync(UnifiedNotificationDto dto, CancellationToken ct);
    }

}
