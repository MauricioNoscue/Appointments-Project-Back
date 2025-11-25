using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Dto.HospitalDto.Citation;
using Entity_Back;

namespace Business_Back.Interface.IBusinessModel
{
    /// <summary>
    /// Define las operaciones principales relacionadas con el manejo de citas médicas,
    /// incluyendo la obtención de bloques de tiempo disponibles y la generación de horarios.
    /// </summary>
    public interface ICitationCoreService
    {
        /// <summary>
        /// Obtiene los bloques horarios disponibles para un tipo de cita específico,
        /// según su configuración de horario (Shedule) y fecha indicada.
        /// </summary>
        /// <param name="typeCitationId">Identificador del tipo de cita.</param>
        /// <param name="fecha">Fecha en la que se consultarán los bloques.</param>
        /// <param name="incluirOcupados">
        /// Indica si se deben incluir también los bloques ocupados (true) o solo los disponibles (false).
        /// </param>
        /// <returns>Lista de bloques de tiempo con su estado de disponibilidad.</returns>
        Task<List<TimeBlockEstado>> GetAvailableTimeBlocksByTypeCitationIdAsync(
            int typeCitationId,
            DateTime fecha,
            bool incluirOcupados = false
        );

        /// <summary>
        /// Calcula los bloques horarios posibles según la configuración de un horario (ScheduleHour).
        /// </summary>
        /// <param name="scheduleHour">Entidad con los datos de horario y su configuración asociada.</param>
        /// <returns>Lista de horas (TimeSpan) que representan los posibles bloques de atención.</returns>
        List<TimeSpan> CalcularBloquesHorarios(ScheduleHour scheduleHour);

        /// <summary>
        /// Filtra los bloques horarios para identificar cuáles están disponibles y cuáles no.
        /// </summary>
        /// <param name="todosLosBloques">Lista de todos los bloques generados.</param>
        /// <param name="bloquesOcupados">Lista de bloques actualmente ocupados.</param>
        /// <param name="incluirOcupados">
        /// Indica si se deben incluir los ocupados o solo los disponibles.
        /// </param>
        /// <returns>Lista de bloques con su estado de disponibilidad.</returns>
        List<TimeBlockEstado> FiltrarBloquesDisponibles(
     List<TimeSpan> todosLosBloques,
     List<TimeSpan> bloquesOcupados,
     bool incluirOcupados = false,
     int scheduleHourId = 0);



        List<TimeBlockEstado> FiltrarBloquesPorFechaActual(
   List<TimeBlockEstado> bloques,
   DateTime fecha);
    }
}
