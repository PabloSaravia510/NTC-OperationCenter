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
    public class AprobadoresGADal : IAprobadoresGA<AprobadoresGA>
    {
        Conexion bd = new Conexion();

        public void ActualizarAprobadoresGA(AprobadoresGA p)
        {
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_ActualizarAprobadoresGA", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idAprobadoresGA", p.Id_Aprobadores_GA);
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

        public AprobadoresGA BuscarAprobadoresGA(int id)
        {
            AprobadoresGA aprobadoresGA = null;
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_BuscarAprobadoresGA", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idAprobadoresGA", id);

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    aprobadoresGA = new AprobadoresGA()
                    {
                        Id_Aprobadores_GA = dr.GetInt32(0),
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
            return aprobadoresGA;
        }

        public void EliminarAprobadoresGA(AprobadoresGA p)
        {
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_EliminarAprobadoresGA", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idAprobadoresGA", p.Id_Aprobadores_GA);

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

        public void InsertAprobadoresGA(AprobadoresGA p)
        {
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_InsertarAprobadoresGA", cn);
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

        public List<AprobadoresGA> ListaAprobadoresGA()
        {
            List<AprobadoresGA> lista = new List<AprobadoresGA>();
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_ListarAprobadoresGA", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    AprobadoresGA p = new AprobadoresGA()
                    {
                        Id_Aprobadores_GA = dr.GetInt32(0),
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
