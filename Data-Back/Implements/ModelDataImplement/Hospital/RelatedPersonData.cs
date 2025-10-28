using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data_Back.Implements.BaseModelData;
using Data_Back.Interface.IDataModels.Hospital;
using Entity_Back.Context;
using Entity_Back.Models.HospitalModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data_Back.Implements.ModelDataImplement.Hospital
{
    public class RelatedPersonData : BaseModelData<RelatedPerson>, IRelatedPersonData
    {
        private readonly ApplicationDbContext _ctx;

        public RelatedPersonData(
            ApplicationDbContext context,
            ILogger<BaseModelData<RelatedPerson>> logger
        ) : base(context, logger)
        {
            _ctx = context;
        }

  

        public override async Task<RelatedPerson?> GetById(int id)
        {
            try
            {
                return await _ctx.Set<RelatedPerson>()
                    .AsNoTracking() // evita devolver caché de tracking
                    .Include(x => x.DocumentType)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en GetById de RelatedPerson con ID: {Id}", id);
                throw;
            }
        }

        public override async Task<IEnumerable<RelatedPerson>> GetAll()
        {
            try
            {
                return await _ctx.Set<RelatedPerson>()
                    .AsNoTracking() // lecturas siempre frescas
                    .Include(x => x.DocumentType)
                    .Where(x => !x.IsDeleted)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en GetAll de RelatedPerson");
                throw;
            }
        }

        // Requerido por la interfaz, ahora también sin tracking
        public async Task<RelatedPerson> GetByIdAsync(int id)
        {
            var entity = await _ctx.Set<RelatedPerson>()
                .AsNoTracking()
                .Include(x => x.DocumentType)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                throw new InvalidOperationException("RelatedPerson no existe.");

            return entity;
        }

        public async Task<List<RelatedPerson>> GetByPersonAsync(int personId)
        {
            return await _ctx.Set<RelatedPerson>()
                .AsNoTracking()
                .Include(x => x.DocumentType)
                .Where(x => x.PersonId == personId)
                .ToListAsync();
        }

        public async Task<bool> ExistsDocumentAsync(int personId, int documentTypeId, string document, int? excludeId = null)
        {
            var q = _ctx.Set<RelatedPerson>()
                .Where(x => x.PersonId == personId
                         && x.DocumentTypeId == documentTypeId
                         && x.Document == document);

            if (excludeId.HasValue)
                q = q.Where(x => x.Id != excludeId.Value);

            return await q.AnyAsync();
        }
        public override async Task<bool> Delete(int id)
        {
            try
            {
                var entity = await _ctx.Set<RelatedPerson>().FindAsync(id);
                if (entity == null) return false;

                _ctx.Set<RelatedPerson>().Remove(entity);
                await _ctx.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en Delete (físico) de RelatedPerson con ID: {Id}", id);
                throw;
            }
        }

        // ==== UPDATE selectivo (sin tocar la FK) ====
        public override async Task<bool> Update(RelatedPerson entity)
        {
            var entry = _ctx.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                _ctx.Set<RelatedPerson>().Attach(entity);
                entry = _ctx.Entry(entity);
            }

            entry.State = EntityState.Unchanged;

            entry.Property(e => e.PersonId).IsModified = false; // FK protegida
            entry.Property(e => e.FirstName).IsModified = true;
            entry.Property(e => e.LastName).IsModified = true;
            entry.Property(e => e.Relation).IsModified = true;
            entry.Property(e => e.DocumentTypeId).IsModified = true;
            entry.Property(e => e.Document).IsModified = true;

            var rows = await _ctx.SaveChangesAsync();
            Console.WriteLine($"[RPD] rows => {rows}");
            return rows > 0;  // verdadero solo si hubo cambios
        }
    }
}
