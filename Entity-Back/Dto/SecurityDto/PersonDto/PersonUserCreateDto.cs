using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Enum;

namespace Entity_Back.Dto.SecurityDto.PersonDto
{
    // DTO para crear una Persona y su Usuario asociado
    public class PersonUserCreateDto
    {
        // ==== Datos Person ====

        /// <summary>
        /// Nombre completo de la persona
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Apellidos completos
        /// </summary>
        public string FullLastName { get; set; }

        /// <summary>
        /// Tipo de documento (Id)
        /// </summary>
        public int DocumentTypeId { get; set; }

        /// <summary>
        /// Número de documento
        /// </summary>
        public string Document { get; set; }

        /// <summary>
        /// Fecha de nacimiento
        /// </summary>
        public DateTime DateBorn { get; set; }

        /// <summary>
        /// Teléfono de contacto
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Género
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Régimen de salud
        /// </summary>
        public HealthRegime HealthRegime { get; set; }

        /// <summary>
        /// Id de la EPS asociada
        /// </summary>
        public int EpsId { get; set; }

        /// <summary>
        /// Dirección
        /// </summary>
        public string? Address { get; set; }


        // ==== Datos User ====

        /// <summary>
        /// Correo del usuario
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Contraseña
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Indica si puede reprogramar citas
        /// </summary>
        public bool Rescheduling { get; set; } = false;

        /// <summary>
        /// Puntos de restricción iniciales (por defecto 3)
        /// </summary>
        public int RestrictionPoint { get; set; } = 3;
    }

}
