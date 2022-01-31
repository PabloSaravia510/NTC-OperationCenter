using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Interface.IGestionAccesos
{
    public interface ISolicitanteGA<T>
    {
        List<T> ListaSolicitanteGA();
        void InsertSolicitanteGA(T p);
        void ActualizarSolicitanteGA(T p);
        void EliminarSolicitanteGA(T p);

        T BuscarSolicitanteGA(int id);
    }
}
