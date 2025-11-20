using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Enum
{
    /// <summary>
    /// Types of notifications available in the system.
    /// </summary>
    public enum NotificationTemplate
    {
        // ===== CITAS =====

        /// <summary>
        /// Cita enviada
        /// </summary>
        AppointmentSent,

        /// <summary>
        /// Cita cancelada
        /// </summary>
        AppointmentCanceled,

        /// <summary>
        /// Cita reprogramada
        /// </summary>
        AppointmentRescheduled,

        /// <summary>
        /// Cita pendiente
        /// </summary>
        AppointmentPending,

        /// <summary>
        /// Cita fallada / No asistió
        /// </summary>
        AppointmentFailed,

        /// <summary>
        /// Recordatorio de cita pendiente
        /// </summary>
        AppointmentPendingReminder,

        /// <summary>
        /// Recordatorio de cita fallada / no asistida
        /// </summary>
        AppointmentFailedReminder,


        // ===== AUTENTICACIÓN =====

        /// <summary>
        /// Inicio de sesión
        /// </summary>
        Login,

        /// <summary>
        /// Bloqueo de cuenta
        /// </summary>
        AccountLocked,



        // ===== PUNTOS / SISTEMA =====

        /// <summary>
        /// Pérdida de un punto
        /// </summary>
        PointLost,



        // ===== PERMISOS =====

        /// <summary>
        /// Solicitud de permiso enviada
        /// </summary>
        PermissionRequestSent,

        /// <summary>
        /// Solicitud de permiso cancelada
        /// </summary>
        PermissionRequestCanceled,

        /// <summary>
        /// Solicitud de permiso aprobada
        /// </summary>
        PermissionRequestApproved,



        // ===== USUARIOS / GESTIÓN =====

        /// <summary>
        /// Bienvenido
        /// </summary>
        Welcome,

        /// <summary>
        /// Persona relacionada agregada
        /// </summary>
        RelatedPersonAdded
    }

}
