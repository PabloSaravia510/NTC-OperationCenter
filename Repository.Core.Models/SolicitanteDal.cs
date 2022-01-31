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
    public class SolicitanteDal : ISolicitante<Solicitante>
    {
        Conexion bd = new Conexion();


        public List<Solicitante> ListarSolicitanteDal()
        {
            List<Solicitante> lista = new List<Solicitante>();
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_ListarSolicitante", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Solicitante p = new Solicitante()
                    {
                        Id_Solicitante = dr.GetInt32(0),
                        Nombres = dr.GetString(1),
                        Apellidos = dr.GetString(2),
                        Equipo = dr.GetString(3)
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

        public List<Solicitante> ListarcboSolicitanteDal()
        {
            List<Solicitante> lista = new List<Solicitante>();
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_ListarcboSolicitante", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Solicitante p = new Solicitante()
                    {
                        Id_Solicitante = dr.GetInt32(0),
                        Nombres = dr.GetString(1),
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
