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
    public class TipoPaseDal : ITipoPase<TipoPase>
    {
        Conexion bd = new Conexion();

        public void ActualizarTpPase(TipoPase p)
        {
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_ActualizarTipoPase", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idTipoPase", p.Id_TpPase);
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

        public TipoPase BuscarTpPase(int id)
        {
            TipoPase tipoPase = null;
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_BuscarTipoPase", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idTipoPase", id);

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    tipoPase = new TipoPase()
                    {
                        Id_TpPase = dr.GetInt32(0),
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
            return tipoPase;
        }

        public void EliminarTpPase(TipoPase p)
        {
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_EliminarTipoPase", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idTipoPase", p.Id_TpPase);

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

        public void InsertarTpPase(TipoPase p)
        {
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_InsertarTipoPase", cn);
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

        public List<TipoPase> ListarTpPaseDal()
        {
            List<TipoPase> lista = new List<TipoPase>();
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_ListarTipoPase", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TipoPase p = new TipoPase()
                    {
                        Id_TpPase = dr.GetInt32(0),
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
