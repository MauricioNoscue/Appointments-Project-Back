using Data_Back.Implements.BaseModelData;
using Data_Back.Implements.ModelDataImplement.Infrastructure;
using Data_Back.Interface.IDataModels.Notifation;
using Entity_Back.Context;
using Entity_Back.Models.Infrastructure;
using Entity_Back.Models.Notification;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Back.Implements.ModelDataImplement.Notification1
{
   public class NotificationData : BaseModelData<Notification>, INotificationData
    {
        public NotificationData(ApplicationDbContext context, ILogger<NotificationData> logger)
                  : base(context, logger)
        {

        }
        public override async Task<IEnumerable<Notification>> GetAll()
        {
            try
            {
                var ltsModel = await _context.Set<Notification>()
                    .AsNoTracking()
                    .Include(n => n.citation)                     // navega a Citation (prop minúscula)
                        .ThenInclude(c => c.ScheduleHour)          // Citation → ScheduleHour
                            .ThenInclude(sh => sh.Shedule)         // ScheduleHour → Shedule
                                .ThenInclude(s => s.TypeCitation)  // Shedule → TypeCitation
                    .Where(n => !n.IsDeleted)
                    .ToListAsync();

                return ltsModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener todos los registros de la entidad {typeof(Notification).Name}");
                throw;
            }
        }
    }
}