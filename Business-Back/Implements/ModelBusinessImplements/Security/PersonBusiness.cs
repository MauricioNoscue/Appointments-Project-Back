﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Implements.BaseModelBusiness;
using Business_Back.Interface.IBusinessModel.Security;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Dto.SecurityDto.PersonDto;
using Entity_Back.Enum;
using Entity_Back.Models.SecurityModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Utilities_Back.Exceptions;

namespace Business_Back.Implements.ModelBusinessImplements.Security
{
    public class PersonBusiness :BaseModelBusinessIm<Person,PersonCreatedDto,PersonEditDto,PersonListDto>,IPersonBusiness
    {

        private readonly IpersonData _data;

        public PersonBusiness(IConfiguration configuration, IpersonData data, ILogger<PersonBusiness> logger) :
            base(configuration, data, logger)
        {
            _data = data;
        }


        public override async Task ValidateAsync(Person entity)
        {
            var errors = new List<(string Field, string Message)>();

            if (string.IsNullOrWhiteSpace(entity.FullName))
                errors.Add(("FullName", "El nombre completo es obligatorio."));

            if (string.IsNullOrWhiteSpace(entity.FullLastName))
                errors.Add(("FullLastName", "El apellido completo es obligatorio."));

            if (entity.DocumentTypeId <= 0)
                errors.Add(("DocumentTypeId", "Debe seleccionar un tipo de documento."));

            if (string.IsNullOrWhiteSpace(entity.Document))
                errors.Add(("Document", "El número de documento es obligatorio."));
            else if (await _data.ExistsByAsync(x => x.Document, entity.Document))
                errors.Add(("Document", "El número de documento ya existe."));

            if (entity.DateBorn == default)
                errors.Add(("DateBorn", "La fecha de nacimiento es obligatoria."));
            else if (entity.DateBorn.Date >= DateTime.UtcNow.Date)
                errors.Add(("DateBorn", "La fecha de nacimiento debe ser anterior a hoy."));

            if (!string.IsNullOrWhiteSpace(entity.PhoneNumber))
            {
                if (await _data.ExistsByAsync(x => x.PhoneNumber, entity.PhoneNumber))
                    errors.Add(("PhoneNumber", "El teléfono ya está registrado."));
            }

            if (entity.EpsId <= 0)
                errors.Add(("EpsId", "Debe seleccionar la EPS."));
            if (!Enum.IsDefined(typeof(Gender), entity.Gender) || (int)entity.Gender == 0)
                errors.Add(("Gender", "Debe seleccionar un género válido."));

            if (!Enum.IsDefined(typeof(HealthRegime), entity.HealthRegime) || (int)entity.HealthRegime == 0)
                errors.Add(("HealthRegime", "Debe seleccionar un régimen de salud válido."));
            if (errors.Count > 0)
            {
                var combined = string.Join(" | ", errors.Select(e => $"{e.Field}: {e.Message}"));
                throw new ValidationException(errors[0].Field, combined);
            }
        }



    }
}
