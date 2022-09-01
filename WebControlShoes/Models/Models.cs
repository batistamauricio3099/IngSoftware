using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebControlShoes.Models
{
    public class Models
    {
        [Key]
        public int SKU { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        public int LimInfR { get; set; }
        public int LiSupR { get; set; }
        public int LimInfO { get; set; }
        public int LiSupO { get; set; }
    }
}
