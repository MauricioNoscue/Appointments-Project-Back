using Data_Back.Implements.BaseModelData;
using Data_Back.Implements.ModelDataImplement.Infrastructure;
using Data_Back.Interface.IDataModels.Notifation;
using Entity_Back.Context;
using Entity_Back.Enum;
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
   public class NotificationData : BaseModelData<Notifications>, INotificationData
    {
        public NotificationData(ApplicationDbContext context, ILogger<NotificationData> logger)
                  : base(context, logger)
        {

        }
        public override async Task<IEnumerable<Notifications>> GetAll()
        {
            try
            {
                var ltsModel = await _context.Set<Notifications>()
                    
                    .ToListAsync();

                return ltsModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener todos los registros de la entidad {typeof(Notifications).Name}");
                throw;
            }
        }

        public async Task<bool> UpdateStatusNotification(int id)
        {
            try
            {
                var existingEntity = await _context.Set<Notifications>().FindAsync(id);

                if (existingEntity == null)
                {
                    _logger.LogWarning($"No se pudo actualizar el registro ");
                    return false;
                }

                existingEntity.StateNotification = StatusNotification.Read;

                _context.Entry(existingEntity).CurrentValues.SetValues(existingEntity);
                await _context.SaveChangesAsync();


                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar el estado de la notificación con ID: {id}");
                throw;
            }
        }


        public async Task<IEnumerable<Notifications>> GetNotificationsByUserId(int userId)
        {
            try
            {
                var notifications = await _context.Set<Notifications>()
                    .Include(n => n.citation)
                    .Where(n => n.UserId == userId)
                    .ToListAsync();
                return notifications;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener las notificaciones para el usuario con ID: {userId}");
                throw;
            }
        }

        public override async Task<IEnumerable<Notifications>> GetAllUser(int userId)
        {
            try
            {
                var ltsModel = await _context.Set<Notifications>()
                    .Include(n => n.citation)
                    .Where(n => n.UserId == userId)
                    //.Where(n => !n.IsDeleted)
                    .ToListAsync();
                return ltsModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener todos los registros de la entidad {typeof(Notifications).Name} para el usuario con ID: {userId}");
                throw;
            }
        }
    }
}