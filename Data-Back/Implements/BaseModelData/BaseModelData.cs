using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Context;
using Entity_Back.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data_Back.Implements.BaseModelData
{

    /// <summary>
    /// Implementación genérica de la clase base <see cref="ABaseModelData{T}"/> para realizar operaciones CRUD sobre entidades que heredan de <see cref="BaseModel"/>.
    /// Utiliza Entity Framework y se apoya en inyección de dependencias para el contexto y el logger.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad que hereda de <see cref="BaseModel"/>.</typeparam>

    public class BaseModelData<T> : ABaseModelData<T> where T : BaseModel
    {

        protected readonly ApplicationDbContext _context;
        protected readonly ILogger<BaseModelData<T>> _logger;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseModelData{T}"/> con el contexto de base de datos y el logger.
        /// </summary>
        /// <param name="context">Contexto de base de datos de la aplicación.</param>
        /// <param name="logger">Instancia del logger para registrar errores y eventos.</param>

        public BaseModelData( ApplicationDbContext context, ILogger<BaseModelData<T>> logger)
        {
            _context = context;
            _logger = logger;
        }


        /// <summary>
        /// Obtiene todas las entidades del tipo <typeparamref name="T"/> que no están marcadas como eliminadas lógicamente (`IsDeleted == false`).
        /// </summary>
        /// <returns>Una colección de entidades activas.</returns>

        public override async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                var ltsModel = await _context.Set<T>()
                .Where(e => !e.IsDeleted) 
                .ToListAsync();

                return ltsModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener todos los registros de la entidad {typeof(T).Name}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene todas las entidades del tipo <typeparamref name="T"/>, incluyendo aquellas eliminadas lógicamente.
        /// </summary>
        /// <returns>Una colección completa de entidades, sin filtrar por estado lógico.</returns>

        public override async Task<IEnumerable<T>> GetAllAdmin()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();

            }catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener todos los registros de la entidad {typeof(T).Name}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene una entidad por su identificador único.
        /// </summary>
        /// <param name="id">Identificador de la entidad.</param>
        /// <returns>La entidad correspondiente o null si no existe.</returns>

        public override async Task<T?> GetById(int id)
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el registro {typeof(T).Name} con ID: {id}");
                throw;
            }
        }

        /// <summary>
        /// Guarda una nueva entidad en la base de datos.
        /// </summary>
        /// <param name="entity">Entidad a guardar.</param>
        /// <returns>La entidad guardada, incluyendo su ID asignado por la base de datos.</returns>

        public override  async Task<T> Save(T entity)
        {
            try
            {

                await _context.Set<T>().AddAsync(entity);

                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al crear el registro para la entidad: {typeof(T).Name}");
                throw;
            }
        }

        /// <summary>
        /// Actualiza una entidad existente con los nuevos valores proporcionados.
        /// </summary>
        /// <param name="entity">Entidad con los datos actualizados. Debe incluir el ID existente.</param>
        /// <returns>True si la actualización fue exitosa; false si la entidad no fue encontrada.</returns>

        public override async Task<bool> Update(T entity)
        {
            try
            {
                var existingEntity = await _context.Set<T>().FindAsync(entity.Id);

                if (existingEntity == null)
                {
                    _logger.LogWarning($"Entidad de tipo {typeof(T).Name} con ID {entity.Id} no encontrada para actualización.");
                    return false;
                }

                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar el registro para la entidad: {typeof(T).Name}");
                throw;
            }
        }

        /// <summary>
        /// Elimina físicamente una entidad de la base de datos.
        /// </summary>
        /// <param name="id">Identificador de la entidad a eliminar.</param>
        /// <returns>True si la entidad fue eliminada; false si no fue encontrada.</returns>

        public override async Task<bool> Delete(int id)
        {
            try
            {
                var entity = await _context.Set<T>().FindAsync(id);
                if (entity == null) return false;
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al elimiar el registro para la entidad: {typeof(T).Name}");
                throw;
            }
        }

        /// <summary>
        /// Realiza una eliminación lógica de una entidad, marcándola como eliminada sin quitarla físicamente de la base de datos.
        /// </summary>
        /// <param name="id">Identificador de la entidad.</param>
        /// <returns>True si la eliminación lógica fue exitosa; false si no se encontró la entidad.</returns>

        public override async Task<bool> DeleteLogical(int id)
        {
            try
            {
                var entity = await _context.Set<T>().FindAsync(id);
                if (entity == null) return false;

                entity.IsDeleted = true;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar lógicamente el registro para la entidad: {typeof(T).Name}");
                throw;
            }
        }



        public override async Task<bool> ExistsByAsync(
        Expression<Func<T, object>> fieldSelector,
        object? value)
        {
            if (fieldSelector == null)
                throw new ArgumentNullException(nameof(fieldSelector));

            // extraer nombre de la propiedad
            Expression body = fieldSelector.Body is UnaryExpression u && u.NodeType == ExpressionType.Convert
                ? u.Operand
                : fieldSelector.Body;

            if (body is not MemberExpression m)
                throw new ArgumentException("Selector must be a simple property access, e.g., x => x.Property.");

            string propName = m.Member.Name;
            string p = propName;
            object? v = value;

            return await _context.Set<T>()
                .AsNoTracking()
                .Where(e => EF.Property<object>(e, p) == v)
                .AnyAsync();
        }


        public override async Task<IEnumerable<T>> GetAllUser(int userId)
        {
            try
            {
                var ltsModel = await _context.Set<T>()
                .Where(e => !e.IsDeleted && EF.Property<int>(e, "UserId") == userId)
                .ToListAsync();
                return ltsModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener todos los registros de la entidad {typeof(T).Name} para el usuario con ID: {userId}");
                throw;
            }
        }



        public override async Task<bool> UpdateStatusTypesAsync(int id, int statusTypeId)
        {
            try
            {
                // 1. Buscar el registro por ID (sin asumir que tiene StatustypesId)
                var entity = await _context.Set<T>()
                    .FirstOrDefaultAsync(e => !e.IsDeleted && e.Id == id);

                if (entity == null)
                    return false;

                // 2. Aplicar actualización SOLO si la entidad tiene la propiedad
                _context.Entry(entity).Property("StatustypesId").CurrentValue = statusTypeId;

                // 3. Guardar
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar campo StatustypesId en {typeof(T).Name} con ID: {id}");
                throw;
            }
        }





    }
}
