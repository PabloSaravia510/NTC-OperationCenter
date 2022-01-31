using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core.Entity
{
    public class Categoria
    {
        [DisplayName("Id")]
        public int Id_Categoria { get; set; }
        public string Descripcion { get; set; }
    }
}
