using Data_Back.Implements.BaseModelData;
using Entity_Back;
using Entity_Back.Context;
using Entity_Back.Models.SecurityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data_Back
{
    /// <summary>
    /// Implementación de la interfaz <see cref="ICitationsData"/> para operaciones específicas sobre la entidad <see cref="Citation"/>.
    /// </summary>
    /// <remarks>
    /// Proporciona métodos para obtener, filtrar y manipular citas médicas en la base de datos.
    /// </remarks>
    public class CitationsData : BaseModelData<Citation>, ICitationsData
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CitationsData"/>.
        /// </summary>
        /// <param name="context">Contexto de base de datos de la aplicación.</param>
        /// <param name="logger">Instancia del logger para registrar eventos y errores.</param>
        public CitationsData(ApplicationDbContext context, ILogger<BaseModelData<Citation>> logger)
            : base(context, logger)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene los bloques de tiempo ya utilizados para un horario y fecha específicos.
        /// </summary>
        /// <param name="scheduleHourId">ID del horario.</param>
        /// <param name="appointmentDate">Fecha de la cita.</param>
        /// <returns>Lista de <see cref="TimeSpan"/> con los bloques de tiempo ocupados.</returns>
        /// <remarks>rty: Task&lt;List&lt;TimeSpan&gt;&gt;</remarks>
        public async Task<List<TimeSpan>> GetUsedTimeBlocksByScheduleHourIdAndDateAsync(int scheduleHourId, DateTime appointmentDate)
        {
            return await _context.Set<Citation>()
                .Where(c => c.ScheduleHourId == scheduleHourId &&
                            c.AppointmentDate.Date == appointmentDate.Date &&
                            !c.IsDeleted)
                .Select(c => c.TimeBlock.Value)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene todas las citas no eliminadas, incluyendo relaciones relevantes.
        /// </summary>
        /// <returns>Colección de <see cref="Citation"/>.</returns>
        /// <remarks>rty: Task&lt;IEnumerable&lt;Citation&gt;&gt;</remarks>
        public async override Task<IEnumerable<Citation>> GetAll()
        {
            try
            {
                var lts = await _context.Set<Citation>()
                    .AsNoTracking()
                    .Include(c => c.Statustypes)
                    .Include(c => c.ScheduleHour)
                        .ThenInclude(sh => sh.Shedule)
                            .ThenInclude(s => s.Doctor)
                                .ThenInclude(d => d.Person)
                    .Include(c => c.ScheduleHour)
                        .ThenInclude(sh => sh.Shedule)
                            .ThenInclude(s => s.ConsultingRoom)
                    .Where(c => !c.IsDeleted)
                    .ToListAsync();

                return lts;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener todos los registros de la entidad {typeof(Citation).Name}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene las citas de un doctor para una fecha específica.
        /// </summary>
        /// <param name="doctorId">ID del doctor.</param>
        /// <param name="date">Fecha de la cita.</param>
        /// <returns>Colección de <see cref="Citation"/>.</returns>
        /// <remarks>rty: Task&lt;IEnumerable&lt;Citation&gt;&gt;</remarks>
        public async Task<IEnumerable<Citation>> GetCitationsByDoctor(
              int doctorId,
              DateTime date
          )
        {
            try
            {
                var citations = await _context.Citation
                    .AsNoTracking()
                    .Include(c => c.Statustypes)

                    .Include(c => c.ScheduleHour)
                        .ThenInclude(sh => sh.Shedule)
                            .ThenInclude(s => s.Doctor)
                                .ThenInclude(d => d.Person)
                    .Include(c => c.ScheduleHour)
                        .ThenInclude(sh => sh.Shedule)
                            .ThenInclude(s => s.ConsultingRoom)
                    .Where(c =>
                        !c.IsDeleted &&                                   // no eliminadas
                        c.StatustypesId == 1 &&                           // estado = 1
                        c.ScheduleHour.Shedule.DoctorId == doctorId &&    // citas del doctor
                        c.AppointmentDate.Date == date.Date               // fecha exacta
                    )
                    .ToListAsync();

                return citations;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    $"Error al obtener citas del DoctorId {doctorId} para la fecha {date:yyyy-MM-dd}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene todas las citas de un usuario específico, incluyendo relaciones relevantes.
        /// </summary>
        /// <param name="userId">ID del usuario.</param>
        /// <returns>Lista de <see cref="Citation"/>.</returns>
        /// <remarks>rty: Task&lt;List&lt;Citation&gt;&gt;</remarks>
        public async Task<List<Citation>> GetAllForListAsync(int userId)
        {
            var lts = await _context.Set<Citation>()
                .AsNoTracking()
                    .Include(c => c.Statustypes)

                .Include(c => c.ScheduleHour)
                    .ThenInclude(sh => sh.Shedule)
                        .ThenInclude(s => s.Doctor)
                            .ThenInclude(d => d.Person)
                .Include(c => c.ScheduleHour)
                    .ThenInclude(sh => sh.Shedule)
                        .ThenInclude(s => s.ConsultingRoom)
                .Where(c => !c.IsDeleted && c.UserId == userId)
                .ToListAsync();

            return lts;
        }

        /// <summary>
        /// Obtiene las citas programadas de un doctor para una fecha específica.
        /// </summary>
        /// <param name="doctorId">ID del doctor.</param>
        /// <param name="date">Fecha de la cita.</param>
        /// <returns>Lista de <see cref="Citation"/>.</returns>
        /// <remarks>rty: Task&lt;List&lt;Citation&gt;&gt;</remarks>
        public async Task<List<Citation>> GetCitationsByDoctorAndDate(int doctorId, DateTime date)
        {
            return await _context.Set<Citation>()
                .AsNoTracking()
                .Where(c => !c.IsDeleted &&
                            c.AppointmentDate.Date == date.Date &&
                            c.ScheduleHour.Shedule.DoctorId == doctorId &&
                            c.StatustypesId == 1) // solo programadas
                .Include(c => c.ScheduleHour)
                    .ThenInclude(sh => sh.Shedule)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene todas las citas de un usuario específico, incluyendo relaciones y estado.
        /// </summary>
        /// <param name="userId">ID del usuario.</param>
        /// <returns>Colección de <see cref="Citation"/>.</returns>
        /// <remarks>rty: Task&lt;IEnumerable&lt;Citation&gt;&gt;</remarks>
        public override async Task<IEnumerable<Citation>> GetAllUser(int userId)
        {
            try
            {
                var ltsModel = await _context.Set<Citation>()
                    .AsNoTracking()
                    .Include(c => c.Statustypes)
                    .Include(c => c.ScheduleHour)
                        .ThenInclude(sh => sh.Shedule)
                            .ThenInclude(s => s.Doctor)
                                .ThenInclude(d => d.Person)
                    .Include(c => c.ScheduleHour)
                        .ThenInclude(sh => sh.Shedule)
                            .ThenInclude(s => s.ConsultingRoom)
                    .Where(e => !e.IsDeleted && EF.Property<int>(e, "UserId") == userId)
                    .ToListAsync();
                return ltsModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener todos los registros de la entidad {typeof(Citation).Name} para el usuario con ID: {userId}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene todas las citas asociadas a un doctor para el dashboard.
        /// </summary>
        /// <param name="doctorId">ID del doctor.</param>
        /// <returns>Lista de <see cref="Citation"/>.</returns>
        /// <remarks>rty: Task&lt;List&lt;Citation&gt;&gt;</remarks>
        public async Task<List<Citation>> GetCitationsForDashboardAsync(int doctorId)
        {
            return await _context.Citation
                .AsNoTracking()
                .Include(c => c.ScheduleHour)
                    .ThenInclude(sh => sh.Shedule)
                .Where(c =>
                    !c.IsDeleted &&
                    c.ScheduleHour.Shedule.DoctorId == doctorId
                )
                .ToListAsync();
        }
    }
}