using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core.Interfaces
{
    public interface IOrigen<T>
    {
        List<T> ListarOrigenDal();
        void InsertaOrigen(T p);
        void ActualizarOrigen(T p);
        void EliminarOrigen(T p);
        T BuscarOrigen(int id);
    }
}
