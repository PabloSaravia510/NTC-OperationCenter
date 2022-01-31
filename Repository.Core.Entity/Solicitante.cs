using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core.Entity
{
    public class Solicitante
    {
        [DisplayName("Id")]
        public int Id_Solicitante { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        public int Id_Equipo { get; set; }
        public string Equipo { get; set; }

    }
}
