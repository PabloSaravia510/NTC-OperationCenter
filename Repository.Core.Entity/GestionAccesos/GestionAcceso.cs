using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core.Entity.GestionAccesos
{
    public class GestionAcceso
    {
        public int Id_GestionAcceso { get; set; }
        [Display(Name="Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}",ApplyFormatInEditMode = false)]
        public DateTime? FechaHora { get; set; }
        public int Id_Solicitante_GA { get; set; }
        public string Solicitante { get; set; }
        public string NombreUsuario { get; set; }
        public int Id_Area_GA { get; set; }
        public string Area { get; set; }
        public int Id_Sede_GA { get; set; }
        public string Sede { get; set; }
        public int Id_Servicio_GA { get; set; }
        public string Servicio { get; set; }
        public string DetalleSolicitud { get; set; }
        public int Id_Aprobadores_GA { get; set; }
        public string Aprobadores { get; set; }
        public int Id_Tipo_GA { get; set; }
        public string Tipo { get; set; }
        public string ReferenciaTK { get; set; }
        public int Id_Responsable { get; set; }
        public string Responsable { get; set; }
        public string Username { get; set; }
        public string PerfilSimilar { get; set; }
        public string Observaciones { get; set; }
    }
}
