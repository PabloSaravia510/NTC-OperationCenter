using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core.Interfaces
{
    public interface IAprobador<T>
    {
        List<T> ListaAprobadores();
        void InsertAprobadores(T p);
        void ActualizarAprobadores(T p);
        void EliminarAprobadores(T p);

        T BuscarAprobadores(int id);
    }
}
