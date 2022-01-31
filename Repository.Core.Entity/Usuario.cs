using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core.Entity
{
    public class Usuario
    {
        [DisplayName("Id")]
        public int Id_Usuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public int Id_Categoria { get; set; }
        public string Descripcion { get; set; }

        public int Id_Equipo { get; set; }
        public string Equipo { get; set; }
    }
}
