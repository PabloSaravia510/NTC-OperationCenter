using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core.Interfaces
{
    public interface ITipoPase<T>
    {
        List<T> ListarTpPaseDal();
        void InsertarTpPase(T p);
        void ActualizarTpPase(T p);
        void EliminarTpPase(T p);
        T BuscarTpPase(int id);
    }
}
