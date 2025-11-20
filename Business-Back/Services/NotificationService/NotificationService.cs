using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Interface.Socket;
using Business_Back.Services.Interface;
using Entity_Back.Dto.Notification;

namespace Business_Back.Services.NotificationService
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationSender _sender;

        public NotificationService(INotificationSender sender)
        {
            _sender = sender;
        }

        //public async Task<bool> SentNotification(NotificationCreateDto notificationCreateDto)
        //{
        //    try
        //    {
        //        switch(notificationCreateDto.TypeNotification)




        //    }catch (Exception ex)
        //    {
        //        throw new Exception("error enviando la notificaion");
        //    }
        //}

  
    }

}
