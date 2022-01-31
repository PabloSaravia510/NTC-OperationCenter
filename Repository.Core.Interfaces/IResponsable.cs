using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core.Interfaces
{
   public  interface IResponsable<T>
    {
        List<T> ListarResponsableDal();
        void InsertarResponsable(T p );
        void ActualizarResponsable(T p );
        void EliminarResponsable(T p);
        T BuscarResponsable(int id);
    }
}
