using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core.Interfaces.IGestionAccesos
{
    public interface IAreaGA<T>
    {
        List<T> ListaAreaGA();
        void InsertAreaGA(T p);
        void ActualizarAreaGA(T p);
        void EliminarAreaGA(T p);

        T BuscarAreaGA(int id);
    }
}
