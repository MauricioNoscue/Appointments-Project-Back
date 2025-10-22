using Data_Back.Implements.BaseModelData;
using Entity_Back;
using Entity_Back.Context;
using Entity_Back.Models.SecurityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data_Back
{
    public class CitationsData : BaseModelData<Citation>, ICitationsData
    {
        private readonly ApplicationDbContext _context;

        public CitationsData(ApplicationDbContext context, ILogger<BaseModelData<Citation>> logger)
            : base(context, logger)
        {
            _context = context;
        }
        public async Task<List<TimeSpan>> GetUsedTimeBlocksByScheduleHourIdAndDateAsync(int scheduleHourId, DateTime appointmentDate)
        {
            return await _context.Set<Citation>()
                .Where(c => c.ScheduleHourId == scheduleHourId &&
                            c.AppointmentDate.Date == appointmentDate.Date &&
                            !c.IsDeleted )
                .Select(c => c.TimeBlock.Value)
                .ToListAsync();
        }

        public async override Task<IEnumerable<Citation>> GetAll()
        {
            try
            {
                    var lts = await _context.Set<Citation>()
                        .AsNoTracking()
                        .Include(c => c.ScheduleHour)
                            .ThenInclude(sh => sh.Shedule)
                                .ThenInclude(s => s.Doctor)
                                    .ThenInclude(d => d.Person)
                        .Include(c => c.ScheduleHour)
                            .ThenInclude(sh => sh.Shedule)
                    .ThenInclude(s => s.ConsultingRoom)
                        .Where(c => !c.IsDeleted )
                        .ToListAsync();

                return lts;

            } catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener todos los registros de la entidad {typeof(Citation).Name}");
                throw;
            } 
        }


        public async Task<List<Citation>> GetAllForListAsync(int userId)
        {
            var lts = await _context.Set<Citation>()
                .AsNoTracking()
                .Include(c => c.ScheduleHour)
                    .ThenInclude(sh => sh.Shedule)
                        .ThenInclude(s => s.Doctor)
                            .ThenInclude(d => d.Person) 
                .Include(c => c.ScheduleHour)
                    .ThenInclude(sh => sh.Shedule)
                        .ThenInclude(s => s.ConsultingRoom)
                .Where(c => !c.IsDeleted && c.UserId == userId)
                .ToListAsync();

            //.Select(c => new CitationListDto
            //{
            //    // BaseModel (tu BaseModel tiene Id/IsDeleted/RegistrationDate)
            //    Id = c.Id,
            //    IsDeleted = c.IsDeleted,
            //    RegistrationDate = c.RegistrationDate,

            //    // Propias de Citation
            //    State = c.State,
            //    Note = c.Note,
            //    AppointmentDate = c.AppointmentDate,
            //    TimeBlock = c.TimeBlock,
            //    ScheduleHourId = c.ScheduleHourId,

            //    // Desde Shedule
            //    NameDoctor = c.ScheduleHour.Shedule.Doctor.Person.FullName, // ajusta si no usas Person
            //    ConsultingRoomName = c.ScheduleHour.Shedule.ConsultingRoom.Name,
            //    RoomNumber = c.ScheduleHour.Shedule.ConsultingRoom.RoomNumber
            //})
            //.ToListAsync();

            return lts;
        }


    }
}