using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core.Interfaces.IGestionAccesos
{
    public interface ITipoGA<T>
    {
        List<T> ListaTipoGA();
        void InsertTipoGA(T p);
        void ActualizarTipoGA(T p);
        void EliminarTipoGA(T p);

        T BuscarTipoGA(int id);
    }
}
