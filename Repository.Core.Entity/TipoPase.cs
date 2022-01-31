using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core.Entity
{
    public class TipoPase
    {
        [DisplayName("Id")]
        public int Id_TpPase { get; set; }
        public string Descripcion { get; set; }
    }
}
