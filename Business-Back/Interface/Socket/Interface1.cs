using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Dto.Notification;

namespace Business_Back.Interface.Socket
{
    public interface INotificationSender
    {
        Task SendToUser(int userId, NotificationListDto dto);
    }

}
