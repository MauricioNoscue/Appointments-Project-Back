using Business_Back.Implements.BaseModelBusiness;
using Data_Back.Interface;
using Entity_Back;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Business_Back
{
    public class DoctorBusiness : BaseModelBusinessIm<Doctor, DoctorCreateDto, DoctorEditDto, DoctorListDto>, IDoctorBusiness
    {
        private readonly IDoctorData _data;

        public DoctorBusiness(IConfiguration configuration, IDoctorData data, ILogger<DoctorBusiness> logger)
            : base(configuration, data, logger)
        {
            _data = data;
        }

        public async Task<DoctorListDto?> GetDoctorWithPersonById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("El id debe ser mayor que cero.", nameof(id));
                }

                var doctor = await _data.GetDoctorWithPersonById(id);
                return doctor?.Adapt<DoctorListDto>();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception($"Error al obtener el doctor por PersonId {id}: {ex.Message}", ex);

            }
        }
        public async Task<IEnumerable<DoctorListDto>> GetAllDoctorWithPerson()
        {
            try
            {
                var doctors = await _data.GetAllDoctorWithPerson(); 
                return doctors.Adapt<IEnumerable<DoctorListDto>>();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception($"Error al obtener todos los doctores: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene todas las citas asignadas a un doctor específico
        /// </summary>
        /// <param name="doctorId">ID del doctor</param>
        /// <returns>Lista de citas del doctor</returns>
        public async Task<IEnumerable<CitationListDto>> GetCitationsByDoctorId(int doctorId)
        {
            try
            {
                if (doctorId <= 0)
                {
                    throw new ArgumentException("El id del doctor debe ser mayor que cero.", nameof(doctorId));
                }

                var citations = await _data.GetCitationsByDoctorId(doctorId);
                return citations;
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception($"Error al obtener las citas del doctor {doctorId}: {ex.Message}", ex);
            }
        }
    }
}
