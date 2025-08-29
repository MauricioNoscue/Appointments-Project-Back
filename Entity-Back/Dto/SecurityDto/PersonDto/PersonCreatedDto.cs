using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.SecurityDto.PersonDto
{
    public class PersonCreatedDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El apellido debe tener entre 2 y 100 caracteres")]
        public string FullLastName { get; set; }

        [Required(ErrorMessage = "El tipo de documento es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo de documento válido")]
        public int DocumentTypeId { get; set; }

        [Required(ErrorMessage = "El número de documento es obligatorio")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "El número de documento debe tener entre 5 y 20 caracteres")]
        public string Document { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha inválido")]
        public DateTime DateBorn { get; set; }

        [Required(ErrorMessage = "El número de teléfono es obligatorio")]
        [Phone(ErrorMessage = "Formato de teléfono no válido")]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "El teléfono debe tener entre 8 y 10 dígitos")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "La EPS es obligatoria")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una EPS válida")]
        public int EpsId { get; set; }

        [Required(ErrorMessage = "El género es obligatorio")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "El género debe tener entre 1 y 20 caracteres")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "El régimen de salud es obligatorio")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El régimen de salud debe tener entre 3 y 30 caracteres")]
        public string HealthRegime { get; set; }
    }

}
