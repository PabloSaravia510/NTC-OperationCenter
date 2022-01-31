using Repository.Core.Entity;
using Repository.Core.Interfaces;
using Services.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core.Models
{
    public class UsuariosDal : IUsuarios<Usuario>
    {
        Conexion bd = new Conexion();
        public void ActualizarUsuarios(Usuario p)
        {
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_ActualizarUsuarios", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idUsuario", p.Id_Usuario);
            cmd.Parameters.AddWithValue("@nombres", p.Nombres);
            cmd.Parameters.AddWithValue("@apellidos", p.Apellidos);
            cmd.Parameters.AddWithValue("@username", p.Username);
            cmd.Parameters.AddWithValue("@pwd", p.Password);
            cmd.Parameters.AddWithValue("@idCategoria", p.Id_Categoria);
            cmd.Parameters.AddWithValue("@idEquipo", p.Id_Equipo);
            try
            {
                cn.Open();
                bool iresult = cmd.ExecuteNonQuery() == 1 ? true : false;
                cn.Close();

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public Usuario BuscarUsuarios(int id)
        {
            Usuario usuario = null;
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_BuscarUsuarios", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idUsuario", id);

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    usuario = new Usuario()
                    {
                        Id_Usuario = dr.GetInt32(0),
                        Nombres = dr.GetString(1),
                        Apellidos = dr.GetString(2),
                        Username = dr.GetString(3),
                        Password = dr.GetString(4),
                        Id_Categoria = dr.GetInt32(5),
                        Id_Equipo = dr.GetInt32(6)
                    };
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return usuario;
        }

        public void EliminarUsuarios(Usuario p)
        {
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_EliminarUsuarios", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idUsuario", p.Id_Usuario);

            try
            {
                cn.Open();
                bool iresult = cmd.ExecuteNonQuery() == 1 ? true : false;
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void InsertaUsuarios(Usuario p)
        {
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_InsertarUsuarios", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nombres", p.Nombres);
            cmd.Parameters.AddWithValue("@apellidos", p.Apellidos);
            cmd.Parameters.AddWithValue("@username", p.Username);
            cmd.Parameters.AddWithValue("@pwd", p.Password);
            cmd.Parameters.AddWithValue("@idCategoria", p.Id_Categoria);
            cmd.Parameters.AddWithValue("@idEquipo", p.Id_Equipo);
            try
            {
                cn.Open();
                bool iresult = cmd.ExecuteNonQuery() == 1 ? true : false;
                cn.Close();

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<Usuario> ListarUsuariosDal()
        {
            List<Usuario> lista = new List<Usuario>();
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_ListarUsuarios", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Usuario p = new Usuario()
                    {
                        Id_Usuario = dr.GetInt32(0),
                        Nombres = dr.GetString(1),
                        Apellidos = dr.GetString(2),
                        Username = dr.GetString(3),
                        Descripcion = dr.GetString(4),
                        Equipo = dr.GetString(5)
                    };
                    lista.Add(p);
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lista;
        }

        public Usuario LogIn(string username, string pwd)
        {
            Usuario usuario = null;
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_Login", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@pwd", pwd);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    usuario = new Usuario()
                    {
                        Id_Usuario = dr.GetInt32(0),
                        Nombres = dr.GetString(1),
                        Apellidos = dr.GetString(2),
                        Username = dr.GetString(3),
                        Password = dr.GetString(4),
                        Id_Categoria = dr.GetInt32(5),
                        Id_Equipo = dr.GetInt32(6),
                        Equipo = dr.GetString(7)
                    };
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return usuario;
        }
    }
}
