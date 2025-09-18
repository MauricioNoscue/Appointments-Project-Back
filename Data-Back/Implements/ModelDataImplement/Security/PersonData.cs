using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Back.Implements.BaseModelData;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Context;
using Entity_Back.Models.SecurityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data_Back.Implements.ModelDataImplement.Security
{
    public class PersonData : BaseModelData<Person>,IpersonData
    {
        private readonly ApplicationDbContext _context;

        public PersonData(ApplicationDbContext context, ILogger<PersonData> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAllWithIncludesAsync()
        {
            return await _context.Set<Person>()
                .Include(p => p.DocumentType)
                .Include(p => p.Eps)
                .Where(p => !p.IsDeleted)
                .ToListAsync();
        }

        public async Task<Person?> GetByIdWithIncludesAsync(int id)
        {
            return await _context.Set<Person>()
                .Include(p => p.DocumentType)
                .Include(p => p.Eps)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
        }
    }
}
