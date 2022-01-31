using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core.Interfaces.IGestionAccesos
{
    public interface IGestionAcceso<T>
    {
        List<T> ListaGestionAcceso();
        void InsertGestionAcceso(T p);
        void ActualizarGestionAcceso(T p);
        void EliminarGestionAcceso(T p);

        T BuscarGestionAcceso(int id);
    }
}
