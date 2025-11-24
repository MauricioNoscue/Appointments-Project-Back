using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Interface.BaseModelBusiness;
using Data_Back.Interface.IBaseModelData;
using Entity_Back.Models;
using Entity_Back.Models.SecurityModels;
using Mapster;
using Microsoft.EntityFrameworkCore;
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
                await ValidateAsync(entidad);


                var entiry = await _data.Save(entidad);
                return entiry.Adapt<Dl>();

            }
            catch (ValidationException vex)
            {
                _logger.LogWarning(vex, "Validación fallida en {Entity}", typeof(T).Name);
                throw;
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
            //catch (DbUpdateException dbEx)
            //{
            //    // Capturamos errores de la base de datos y tratamos errores de restricción única
            //    var mensaje = ParseUniqueConstraintError(dbEx);
            //    throw new ValidationException(mensaje);
            //}
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

      

        public virtual string ParseUniqueConstraintError(Exception ex)
        {
            var message = ex.InnerException?.Message ?? ex.Message;

            // Validaciones específicas por índice
            if (message.Contains("IX_User_Email"))
                return "Este correo electrónico ya está registrado.";

            if (message.Contains("IX_ModuleForm_ModuleId_FormId"))
                return "Este formulario ya ha sido asignado al módulo.";

            if (message.Contains("IX_UserRol_UserId_RoleId"))
                return "Este rol ya ha sido asignado al usuario.";

            if (message.Contains("IX_RolFormPermission_RolId_FormId_PermissionId"))
                return "Ya se ha asignado este permiso para el rol y formulario seleccionados.";

            // Mensaje genérico por defecto
            return "Ya existe un registro con esta combinación de datos. Verifica la información.";
        }
        // Valida duplicado por Name en el base, pasando un selector "simple property access" (x => (object)x.Name)
        public override async Task ValidateAsync(T entity)
        {
            // obtener valor de Name desde la instancia (T no expone Name en el base)
            var nameProp = entity.GetType().GetProperty("Name");
            if (nameProp == null) return; // si no existe Name, no valida
            var nameValue = nameProp.GetValue(entity);

            // construir x => (object)x.Name  (MemberExpression + Convert) para cumplir tu ExistsByAsync
            var p = Expression.Parameter(typeof(T), "x");
            var member = Expression.Property(p, "Name");
            var body = Expression.Convert(member, typeof(object));
            var selector = Expression.Lambda<Func<T, object>>(body, p);

            if (await _data.ExistsByAsync(selector, nameValue))
                throw new ValidationException("Name", "El nombre ya está registrado.");
        }

        public override async Task<IEnumerable<Dl>> GetAllUser(int userId)
        {
            try
            {
                // Comentario: obtener entidades desde la capa Data
                var allEntities = await _data.GetAllUser(userId);

                // Comentario: mapear a DTO usando Mapster
                return allEntities.Adapt<IEnumerable<Dl>>();
            }
            catch (BusinessException ex)
            {
                _logger.LogError(ex, "Error al obtener los registros.");
                throw new BusinessException("Ocurrió un error inesperado al consultar los datos.", ex);
            }
        }

        public override Task<bool> UpdateStatusTypesAsync(int id, int statusTypeId, bool? restore = false)
        {
            try
            {

                return _data.UpdateStatusTypesAsync(id, statusTypeId);

            }
            catch (BusinessException)
            {
                throw;

            }
        }
    }
}
