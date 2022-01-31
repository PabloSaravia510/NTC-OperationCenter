using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Interface
{
    public interface IProveedor<T>
    {
        List<T> ListarProveedorDal();
        void InsertarProveedor(T p);
        void ActualizarProveedor(T p);
        void EliminarProveedor(T p);
        T BuscarProveedor(int id);
    }
}
