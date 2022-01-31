using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core.Entity
{
    public class PasesProduccion
    {

        public int Id_PasesProduc { get; set; }
        public int Id_TpPase { get; set; }
        public int Id_Origen { get; set; }
        public string Tk_referencia { get; set; }
        public int Id_Equipo { get; set; }
        public int Id_Proveedor { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Sistema { get; set; }
        public int ID_Det_PaseProduc { get; set; }
        public string Modulo_Sistema { get; set; }
        public string Motivo { get; set; }
        public DateTime? Fec_Solicitud { get; set; }
        public DateTime? Fec_Ejecucion { get; set; }
        public DateTime? Hora_Ejecucion { get; set; }
        public string Observaciones { get; set; }
        public int Id_Aprobador { get; set; }
        public int Id_Responsable { get; set; }





    }
}
