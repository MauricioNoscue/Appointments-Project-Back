using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Interface.BaseModelBusiness;
using Data_Back.Interface.IBaseModelData;
using Entity_Back.Models;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Utilities_Back.Exceptions;

namespace Business_Back.Implements.BaseModelBusiness
{
    public class BaseModelBusinessIm<T, Dc, De, Dl> : ABaseModelBusiness<T, Dc, De, Dl> where T : BaseModel where Dc : class where De : class where Dl : class
    {
        protected readonly IConfiguration _configuration;
        private readonly IBaseModelData<T> _data;
        protected readonly ILogger _logger;
        public BaseModelBusinessIm(IConfiguration configuration, IBaseModelData<T> data, ILogger logger)
        {
            _configuration = configuration;
            _data = data;
            _logger = logger;
        }

        public override async Task<IEnumerable<Dl>> GetAll()
        {
            try
            {
                var allEntities = await _data.GetAll();
                return allEntities.Adapt<IEnumerable<Dl>>();

            }
            catch (BusinessException ex)
            {
                _logger.LogError(ex, $"Error al obtener los reguistros registros  ");
                throw new BusinessException("Ocurrió un error inesperado al consultar los datos.", ex);
            }
        }

        public override async Task<Dl?> GetById(int id)
        {
            if (id <= 0)
                throw new ValidationException(nameof(id), "El identificador debe ser mayor que cero.");

            try
            {
                T entity = await _data.GetById(id);
                return entity.Adapt<Dl>();
            }
            catch (BusinessException ex)
            {
                _logger.LogError(ex, "Error al obtener el registro con ID {Id} de {Entity}", id, typeof(T).Name);
                throw new BusinessException("Ocurrió un error inesperado al consultar los datos.", ex);
            }
        }


        public override async Task<Dl> Save(Dc Dto)
        {

            if (Dto == null)
                throw new ValidationException(nameof(Dto), "Los datos enviados son nulos o inválidos.");
            try
            {
                var entidad = Dto.Adapt<T>();
                var entiry = await _data.Save(entidad);
                return entiry.Adapt<Dl>();

            }
            catch (BusinessException ex)
            {
                _logger.LogError(ex, "Error al crear entidad {Entity}", typeof(T).Name);
                throw new BusinessException("Error al intentar crear el registro.", ex);
            }
        }

        public override async Task<bool> Update(De dto)
        {
            if (dto == null)
                throw new ValidationException(nameof(dto), "Los datos enviados para actualización son inválidos.");

            try
            {
                var entity = dto.Adapt<T>();
                await _data.Update(entity);
                return true;
            }
            catch (BusinessException ex)
            {
                _logger.LogError(ex, "Error al actualizar entidad {Entity}", typeof(T).Name);
                throw new BusinessException("Error al intentar actualizar el registro.", ex);
            }
        }

        public override async Task<bool> Delete(int id)
        {
            if (id <= 0)
                throw new ValidationException(nameof(id), "El identificador debe ser mayor que cero.");

            try
            {
                return await _data.Delete(id);
            }
            catch (BusinessException) { throw; }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar permanentemente el registro con ID {Id} de {Entity}", id, typeof(T).Name);
                throw new BusinessException("Error al eliminar el registro de forma permanente.", ex);
            }
        }

        public override  async Task<bool> DeleteLogical(int id)
        {
            if (id <= 0)
                throw new ValidationException(nameof(id), "El identificador debe ser mayor que cero.");

            try
            {
                return await _data.DeleteLogical(id);
            }
            catch (BusinessException) { throw; }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar lógicamente el registro con ID {Id} de {Entity}", id, typeof(T).Name);
                throw new BusinessException("Error al eliminar el registro de forma lógica.", ex);
            }
        }

        public override void ValidateCreated(Dc dto)
        {
            throw new NotImplementedException();
        }

        public override void ValidateUpdate(Dc dto)
        {
            throw new NotImplementedException();
        }
    }
}
