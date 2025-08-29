using System.Collections.Generic;
using Data_Back.Implements.BaseModelData;
using Data_Back.Interface;
using Entity_Back;
using Entity_Back.Context;
using Entity_Back.Models.SecurityModels;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data_Back.Implements
{
    public class DoctorData : BaseModelData<Doctor>, IDoctorData
    {
        public readonly ApplicationDbContext _context;
        public DoctorData(ApplicationDbContext context, ILogger<BaseModelData<Doctor>> logger)
            : base(context, logger)
        {
            _context = context;
        }

        public async Task<Doctor?> GetDoctorWithPersonById(int id)
        {
            try
            {
                return await _context.Doctors
                            .Include(d => d.Person)
                            .Where(d => d.PersonId == id && !d.IsDeleted)
                            .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception($"Error al obtener el doctor por PersonId {id}: {ex.Message}", ex);
            }
        }
        
        public async Task<IEnumerable<Doctor>> GetAllDoctorWithPerson()
        {
            try
            {
                return await _context.Doctors
                            .Include(d => d.Person)
                            .Where(d => !d.IsDeleted)
                            .ToListAsync();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception($"Error al obtener los doctores por SpecialtyId: {ex.Message}", ex);
            }
        }

        async Task<DoctorListDto?> IDoctorData.GetDoctorWithPersonById(int id)
        {
            try
            {
                var doctor = await _context.Doctors
                    .Include(d => d.Person)
                    .Where(d => d.PersonId == id && !d.IsDeleted)
                    .FirstOrDefaultAsync();

                return doctor?.Adapt<DoctorListDto>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el doctor por PersonId {id}: {ex.Message}", ex);
            }
        }

        async Task<IEnumerable<DoctorListDto>> IDoctorData.GetAllDoctorWithPerson()
        {
            try
            {
                var doctors = await _context.Doctors
                    .Include(d => d.Person)
                    .Where(d => !d.IsDeleted)
                    .ToListAsync();

                return doctors.Adapt<IEnumerable<DoctorListDto>>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener todos los doctores: {ex.Message}", ex);
            }
        }
    }
}
