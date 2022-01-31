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
    public class GestionAccesoDal : IGestionAcceso<GestionAcceso>
    {
        Conexion bd = new Conexion();

        public void ActualizarGestionAcceso(GestionAcceso p)
        {
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_ActualizarGestionAccesos", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", p.Id_GestionAcceso);
            cmd.Parameters.AddWithValue("@fecha", p.FechaHora);
            cmd.Parameters.AddWithValue("@solicitante", p.Id_Solicitante_GA);
            cmd.Parameters.AddWithValue("@nombreUsuario", p.NombreUsuario);
            cmd.Parameters.AddWithValue("@area", p.Id_Area_GA);
            cmd.Parameters.AddWithValue("@sede", p.Id_Sede_GA);
            cmd.Parameters.AddWithValue("@servicio", p.Id_Servicio_GA);
            cmd.Parameters.AddWithValue("@detsolicitud", p.DetalleSolicitud);
            cmd.Parameters.AddWithValue("@aprobadores", p.Id_Aprobadores_GA);
            cmd.Parameters.AddWithValue("@tipo", p.Id_Tipo_GA);
            cmd.Parameters.AddWithValue("@tk", p.ReferenciaTK);
            cmd.Parameters.AddWithValue("@responsable", p.Id_Responsable);
            cmd.Parameters.AddWithValue("@username", p.Username);
            cmd.Parameters.AddWithValue("@perfilsimilar", p.PerfilSimilar);
            cmd.Parameters.AddWithValue("@obs", p.Observaciones);

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

        public GestionAcceso BuscarGestionAcceso(int id)
        {
            GestionAcceso gestionAcceso = null;
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_BuscarGestionAccesos", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    gestionAcceso = new GestionAcceso()
                    {
                        Id_GestionAcceso = dr.GetInt32(0),
                        FechaHora = dr.GetDateTime(1),
                        Id_Solicitante_GA = dr.GetInt32(2),
                        NombreUsuario = dr.GetString(3),
                        Id_Area_GA = dr.GetInt32(4),
                        Id_Sede_GA = dr.GetInt32(5),
                        Id_Servicio_GA = dr.GetInt32(6),
                        DetalleSolicitud = dr.GetString(7),
                        Id_Aprobadores_GA = dr.GetInt32(8),
                        Id_Tipo_GA = dr.GetInt32(9),
                        ReferenciaTK = dr.GetString(10),
                        Id_Responsable = dr.GetInt32(11),
                        Username = dr.GetString(12),
                        PerfilSimilar = dr.GetString(13),
                        Observaciones = dr.GetString(14),
                    };
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return gestionAcceso;
        }

        public void EliminarGestionAcceso(GestionAcceso p)
        {
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_EliminarGestionAccesos", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", p.Id_GestionAcceso);

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

        public void InsertGestionAcceso(GestionAcceso p)
        {
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_InsertarGestionAccesos", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fecha", p.FechaHora);
            cmd.Parameters.AddWithValue("@solicitante", p.Id_Solicitante_GA);
            cmd.Parameters.AddWithValue("@nombreUsuario", p.NombreUsuario);
            cmd.Parameters.AddWithValue("@area", p.Id_Area_GA);
            cmd.Parameters.AddWithValue("@sede", p.Id_Sede_GA);
            cmd.Parameters.AddWithValue("@servicio", p.Id_Servicio_GA);
            cmd.Parameters.AddWithValue("@detsolicitud", p.DetalleSolicitud);
            cmd.Parameters.AddWithValue("@aprobadores", p.Id_Aprobadores_GA);
            cmd.Parameters.AddWithValue("@tipo", p.Id_Tipo_GA);
            cmd.Parameters.AddWithValue("@tk", p.ReferenciaTK);
            cmd.Parameters.AddWithValue("@responsable", p.Id_Responsable);
            cmd.Parameters.AddWithValue("@username", p.Username);
            cmd.Parameters.AddWithValue("@perfilsimilar", p.PerfilSimilar);
            cmd.Parameters.AddWithValue("@obs", p.Observaciones);

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

        public List<GestionAcceso> ListaGestionAcceso()
        {
            List<GestionAcceso> lista = new List<GestionAcceso>();
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_ListarGestionAccesos", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    GestionAcceso p = new GestionAcceso()
                    {
                        Id_GestionAcceso = dr.GetInt32(0),
                        FechaHora = dr.GetDateTime(1),
                        Solicitante = dr.GetString(2),
                        NombreUsuario = dr.GetString(3),
                        Area = dr.GetString(4),
                        Sede = dr.GetString(5),
                        Servicio = dr.GetString(6),
                        DetalleSolicitud = dr.GetString(7),
                        Aprobadores = dr.GetString(8),
                        Tipo = dr.GetString(9),
                        ReferenciaTK = dr.GetString(10),
                        Responsable = dr.GetString(11),
                        Username = dr.GetString(12),
                        PerfilSimilar = dr.GetString(13),
                        Observaciones = dr.GetString(14),
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
