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
    public class ProveedorDal : IProveedor<Proveedor>
    {
        Conexion bd = new Conexion();

        public void ActualizarProveedor(Proveedor p)
        {
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_ActualizarProveedor", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idProveedor", p.Id_Proveedor);
            cmd.Parameters.AddWithValue("@descripcion", p.Descripcion);

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

        public Proveedor BuscarProveedor(int id)
        {
            Proveedor proveedor = null;
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_BuscarProveedor", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idProveedor", id);

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    proveedor = new Proveedor()
                    {
                        Id_Proveedor = dr.GetInt32(0),
                        Descripcion = dr.GetString(1)
                    };
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return proveedor;
        }

        public void EliminarProveedor(Proveedor p)
        {
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_EliminarProveedor", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idProveedor", p.Id_Proveedor);

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

        public void InsertarProveedor(Proveedor p)
        {
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_InsertarProveedor", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@descripcion", p.Descripcion);

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

        public List<Proveedor> ListarProveedorDal()
        {
            List<Proveedor> lista = new List<Proveedor>();
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_ListarProveedor", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Proveedor p = new Proveedor()
                    {
                        Id_Proveedor = dr.GetInt32(0),
                        Descripcion = dr.GetString(1)
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
    }
}
