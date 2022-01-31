using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core.Interfaces
{
    public interface IEquipo<T>
    {
        List<T> ListEquipoDAL();
        void InsertEquipo(T p);
        void ActualizarEquipo(T p);
        void EliminaEquipo(T p);

        T BuscarEquipo(int id);
    }
}
