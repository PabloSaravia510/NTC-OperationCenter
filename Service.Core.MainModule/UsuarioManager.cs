using Repository.Core.Entity;
using Service.Core.Interface;
using Repository.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Service.Core.MainModule
{
    public class UsuarioManager : IUsuarios<Usuario>
    {
        UsuariosDal objUsuario = new UsuariosDal();
        public void ActualizarUsuarios(Usuario p)
        {
            objUsuario.ActualizarUsuarios(p);
        }

        public Usuario BuscarUsuarios(int id)
        {
            return objUsuario.BuscarUsuarios(id);
        }

        public void EliminarUsuarios(Usuario p)
        {
            objUsuario.EliminarUsuarios(p);
        }

        public void InsertaUsuarios(Usuario p)
        {
            objUsuario.InsertaUsuarios(p);
        }

        public List<Usuario> ListarUsuariosDal()
        {
            try
            {
                return objUsuario.ListarUsuariosDal().ToList();
            }catch(SqlException ex)
            {
                throw ex;
            }
           
        }

        public Usuario LogIn(string username, string pwd)
        {
            return objUsuario.LogIn(username, pwd);
        }
    }
}
