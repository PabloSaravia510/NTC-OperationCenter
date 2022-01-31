using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Interface
{
    public interface IUsuarios<T>
    {
        List<T> ListarUsuariosDal();
        void InsertaUsuarios(T p);
        void ActualizarUsuarios(T p);
        void EliminarUsuarios(T p);
        T BuscarUsuarios(int id);
        T LogIn(string username, string pwd);
    }
}
