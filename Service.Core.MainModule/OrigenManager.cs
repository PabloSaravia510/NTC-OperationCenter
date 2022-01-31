using Repository.Core.Entity;
using Repository.Core.Models;
using Service.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.MainModule
{
    public class OrigenManager : IOrigen<Origen>
    {
        OrigenDal objorigen = new OrigenDal();
        public void ActualizarOrigen(Origen p)
        {
            objorigen.ActualizarOrigen(p);
        }

        public Origen BuscarOrigen(int id)
        {
            return objorigen.BuscarOrigen(id);
        }

        public void EliminarOrigen(Origen p)
        {
            objorigen.EliminarOrigen(p);
        }

        public void InsertaOrigen(Origen p)
        {
            objorigen.InsertaOrigen(p);
        }

        public List<Origen> ListarOrigen()
        {
            return objorigen.ListarOrigenDal().ToList();
        }
    }
}
