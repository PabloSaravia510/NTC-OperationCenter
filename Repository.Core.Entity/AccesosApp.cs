using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core.Entity
{
    public class AccesosApp
    {
        [DisplayName("Id")]
        public int Id_AccesoApp { get; set; }
        public int Id_Equipo { get; set; }
        public string Equipo { get; set; }
        public int Id_Solicitante { get; set; }
        public string Solicitante { get; set; }
        public string tk_referencia { get; set; }
        public int Id_Responsable { get; set; }
        public string Responsable { get; set; }
        public string Descripcion { get; set; }
        public int Id_Solicitud { get; set; }
        public string Solicitud { get; set; }
        //public int Id_Estado { get; set; }
        public string Estado { get; set; }

        public int Id_Usuario { get; set; }
        public string Usuario { get; set; }

    }
}
