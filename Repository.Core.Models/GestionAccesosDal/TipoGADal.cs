using Repository.Core.Entity.GestionAccesos;
using Repository.Core.Interfaces.IGestionAccesos;
using Services.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core.Models.GestionAccesosDal
{
    public class TipoGADal : ITipoGA<TipoGA>
    {
        Conexion bd = new Conexion();

        public void ActualizarTipoGA(TipoGA p)
        {
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_ActualizarTipoGA", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idTipoGA", p.Id_Tipo_GA);
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

        public TipoGA BuscarTipoGA(int id)
        {
            TipoGA tipoGA = null;
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_BuscarTipoGA", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idTipoGA", id);

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    tipoGA = new TipoGA()
                    {
                        Id_Tipo_GA = dr.GetInt32(0),
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
            return tipoGA;
        }

        public void EliminarTipoGA(TipoGA p)
        {
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_EliminarTipoGA", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idTipoGA", p.Id_Tipo_GA);

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

        public void InsertTipoGA(TipoGA p)
        {
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_InsertarTipoGA", cn);
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

        public List<TipoGA> ListaTipoGA()
        {
            List<TipoGA> lista = new List<TipoGA>();
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_ListarTipoGA", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TipoGA p = new TipoGA()
                    {
                        Id_Tipo_GA = dr.GetInt32(0),
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
