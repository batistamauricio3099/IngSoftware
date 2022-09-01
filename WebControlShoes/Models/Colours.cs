using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebControlShoes.Models
{
    public class Colours
    {
        [Key]
        public int IdColours { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [Display(Name = "Descripción")]
        public string Description { get; set; }
    }
}
