using Business_Back.Implements.BaseModelBusiness;
using Business_Back.Implements.ModelBusinessImplements.Infrastructure;
using Business_Back.Interface.IBusinessModel.Notification;
using Data_Back.Interface.IDataModels.Infrastructure;
using Data_Back.Interface.IDataModels.Notifation;
using Entity_Back.Dto.Notification;
using Entity_Back.Models.Notification;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Back.Implements.ModelBusinessImplements.Notification1
{
    public class NotificationBusiness : BaseModelBusinessIm<Notification,NotificationCreateDto, NotificationEditDto, NotificationListDto>, INotificationBusiness
    {
        private readonly INotificationData _data;
        public NotificationBusiness(IConfiguration configuration, INotificationData data, ILogger<NotificationBusiness> logger)
           : base(configuration, data, logger)
        {
            _data = data;
        }
    }
}
