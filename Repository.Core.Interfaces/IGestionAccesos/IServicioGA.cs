using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core.Interfaces.IGestionAccesos
{
    public interface IServicioGA<T>
    {
        List<T> ListaServicioGA();
        void InsertServicioGA(T p);
        void ActualizarServicioGA(T p);
        void EliminarServicioGA(T p);

        T BuscarServicioGA(int id);
    }
}
