using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDomingo.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required,MaxLength(50)]
        public string Nombres { get; set; }
        [Required, MaxLength(50)]
        public string Apellidos { get; set; }
        [Required,MinLength(1),MaxLength(1)]
        public char Genero { get; set; }
        [Required,MinLength(11),MaxLength(11)]
        public string Cedula { get; set; }
        [Required]
        public string IdDepartamento { get; set; }
        [Required,MaxLength(40)]
        public string Cargo { get; set; }
        public string Supervisor { get; set; }

    }
}
