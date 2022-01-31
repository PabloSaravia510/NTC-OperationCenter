using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Interface
{
    public interface IResponsable<T>
    {
        List<T> ListarResponsable();
        void InsertarResponsable(T p);
        void ActualizarResponsable(T p);
        void EliminarResponsable(T p);
        T BuscarResponsable(int id);
    }
}
