using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Interface.IGestionAccesos
{
    public interface ISedeGA<T>
    {
        List<T> ListaSedeGA();
        void InsertSedeGA(T p);
        void ActualizarSedeGA(T p);
        void EliminarSedeGA(T p);

        T BuscarSedeGA(int id);
    }
}
