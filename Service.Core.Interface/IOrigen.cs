using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Interface
{
    public interface IOrigen<T>
    {
        List<T> ListarOrigen();
        void InsertaOrigen(T p);
        void ActualizarOrigen(T p);
        void EliminarOrigen(T p);
        T BuscarOrigen(int id);
    }
}
