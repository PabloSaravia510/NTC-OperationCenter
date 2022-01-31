using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core.Entity.GestionAccesos
{
    public class SolicitanteGA
    {
        [DisplayName("Id")]
        public int Id_Solicitante_GA { get; set; }
        public string Descripcion { get; set; }
    }
}
