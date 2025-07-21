using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Implements.BaseModelBusiness;
using Business_Back.Interface.IBusinessModel.Security;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Dto.SecurityDto.RolDto;
using Entity_Back.Models.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Business_Back.Implements.ModelBusinessImplements.Security
{
    public class RolBusiness : BaseModelBusinessIm<Rol,RolCreatedDto,RolEditDto,RolListDto>,IRolBusiness
    {
        private readonly IRolData _data;

        public RolBusiness(IConfiguration configuration,IRolData data,ILogger<RolBusiness> logger):
            base(configuration,data,logger)
        {
            _data = data;
        }


        //public override void ValidateCreated(RolCreatedDto dto)
        //{
        //    if (dto == null)
        //        throw new ValidationException("El formulario no puede ser nulo.");

        //    var errors = new List<string>();

        //    if (string.IsNullOrWhiteSpace(dto.Name))
        //        errors.Add("El nombre es obligatorio.");

     

        //    // Validación de unicidad
        //    if (.Forms.Any(f => f.Name == dto.Name))
        //        errors.Add("El nombre ya está en uso.");

        //    if (_context.Forms.Any(f => f.Url == dto.Url))
        //        errors.Add("La URL ya está en uso.");

        //    if (errors.Any())
        //        throw new ValidationException(string.Join(" | ", errors));
        //}
    }
}
