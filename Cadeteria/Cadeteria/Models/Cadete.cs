using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Models
{
    public class Cadete
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="por favor ingrese su Apellido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "por favor ingrese su nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "por favor ingrese su domicilio")]
        public string Domicilio { get; set; }
        [Required(ErrorMessage = "por favor ingrese su telefono")]
        public string Telefono { get; set; }

    }
}
