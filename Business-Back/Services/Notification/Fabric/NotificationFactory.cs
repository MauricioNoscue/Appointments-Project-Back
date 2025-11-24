using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Enum;

namespace Business_Back.Services.Notification.Fabric
{
    /// <summary>
    /// Fábrica estática para construir notificaciones relacionadas con el ciclo de vida de las citas.
    /// Proporciona métodos para generar los títulos, mensajes, tipo de notificación y estado correspondiente.
    /// </summary>
    public static class NotificationFactory
    {
        /// <summary>
        /// Construye una notificación para cuando una cita es creada exitosamente.
        /// </summary>
        /// <returns>Tupla con título, mensaje, tipo de notificación y estado.</returns>
        public static (string title, string message, TypeNotification type, int statusId)
            BuildCitationCreated()
            => ("Cita programada", "Tu cita fue creada correctamente.", TypeNotification.Info, 1);

        /// <summary>
        /// Construye una notificación para cuando una cita es reprogramada.
        /// </summary>
        /// <returns>Tupla con título, mensaje, tipo de notificación y estado.</returns>
        public static (string title, string message, TypeNotification type, int statusId)
            BuildCitationRescheduled()
            => ("Cita reprogramada", "Tu cita fue reprogramada.", TypeNotification.Info, 5);

        /// <summary>
        /// Construye una notificación para cuando una cita es cancelada.
        /// </summary>
        /// <returns>Tupla con título, mensaje, tipo de notificación y estado.</returns>
        public static (string title, string message, TypeNotification type, int statusId)
            BuildCitationCanceled()
            => ("Cita cancelada", "Tu cita fue cancelada.", TypeNotification.Warning, 2);

        /// <summary>
        /// Construye una notificación para cuando una modificación de cita es aprobada.
        /// </summary>
        /// <returns>Tupla con título, mensaje, tipo de notificación y estado.</returns>
        public static (string title, string message, TypeNotification type, int statusId)
        BuildModificationApproved()
              => ("Solicitud aprovada", "Tu cita aprovada.", TypeNotification.Info, 8);

        /// <summary>
        /// Construye una notificación para cuando una modificación de cita es rechazada.
        /// </summary>
        /// <returns>Tupla con título, mensaje, tipo de notificación y estado.</returns>
        public static (string title, string message, TypeNotification type, int statusId)
       BuildModificationRejected()
             => ("Solicitud rechazada", "Tu cita rechazada.", TypeNotification.Info, 9);

        /// <summary>
        /// Construye una notificación para cuando una cita es marcada como no asistida.
        /// </summary>
        /// <returns>Tupla con título, mensaje, tipo de notificación y estado.</returns>
        public static (string title, string message, TypeNotification type, int statusId) BuildCitationMissed()
        {
            try
            {
                return (
                    title: "Cita No Asistida",
                    message: "Tu cita programada fue marcada como no asistida.",
                    type: TypeNotification.Warning,
                    statusId: 3
                );
            }
            catch (Exception ex)
            {
                // Manejo de excepción opcional, lanzar o registrar según sea necesario
                throw;
            }
        }

        /// <summary>
        /// Construye una notificación para cuando una cita es atendida correctamente.
        /// </summary>
        /// <returns>Tupla con título, mensaje, tipo de notificación y estado.</returns>
        public static (string title, string message, TypeNotification type, int statusId) BuildCitationCompleted()
        {
            try
            {
                return (
                    title: "Cita Atendida",
                    message: "Gracias por asistir. Tu cita fue atendida correctamente.",
                    type: TypeNotification.Info,
                    statusId: 4
                );
            }
            catch (Exception ex)
            {
                // Manejo de excepción opcional, lanzar o registrar según sea necesario
                throw;
            }
        }
    }

}
