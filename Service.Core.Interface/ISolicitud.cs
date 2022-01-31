using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Interface
{
    public interface ISolicitud<T>
    {
        List<T> ListarSolcitudDal();
        void InsertarSolicitud(T p);
        void ActualizarSolicitud(T p);
        void EliminarSolicitud(T p);
        T BuscarSolicitud(int id);
    }
}
