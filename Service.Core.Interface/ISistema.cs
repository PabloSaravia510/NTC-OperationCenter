using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Interface
{
    public interface ISistema<T>
    {
        List<T> ListarSistemaDal();
        void InsertarSistema(T p);
        void ActualizarSistema(T p);
        void EliminarSistema(T p);
        T BuscarSistema(int id);
    }
}
