using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core.Interfaces.IGestionAccesos
{
    public interface IAprobadoresGA<T>
    {
        List<T> ListaAprobadoresGA();
        void InsertAprobadoresGA(T p);
        void ActualizarAprobadoresGA(T p);
        void EliminarAprobadoresGA(T p);

        T BuscarAprobadoresGA(int id);
    }
}
