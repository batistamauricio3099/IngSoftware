using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebControlShoes.Areas.Users.Models
{
    public class InputModelRegister
    {
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string Name { get; set;}

        [Required(ErrorMessage = "El campo apellido es obligatorio")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El campo DNI es obligatorio")]
        public string DNI { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es obligatorio")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{2})\)?[-. ]?([0-9]{2})[-. ]?([0-9]{5})$", ErrorMessage = "El formato telefonico ingresado no es valido.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "El campo correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "No es una dirección de correo electrónico válida")]
        public string Email { get; set; }

        [Display(Name= "Contraseña")]
        [Required(ErrorMessage = "El campo contraseña es obligatoria")]
        [StringLength(20, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}", MinimumLength = 8)]
        public string Password { get; set; }

        //[Required]
        public string Role { get; set; }

    }
}
