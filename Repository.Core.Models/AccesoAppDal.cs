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
    public class AccesoAppDal : IAccesoApp<AccesosApp>
    {
        Conexion bd = new Conexion();
        public void ActualizarAccesoAppAdmin(AccesosApp p)
        {
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_ActualizarAccesoAppAdmin", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idAccesoApp", p.Id_AccesoApp);
            cmd.Parameters.AddWithValue("@idequipo", p.Id_Equipo);
            cmd.Parameters.AddWithValue("@idsolicitud", p.Id_Solicitud);
            cmd.Parameters.AddWithValue("@tk_referencia", p.tk_referencia);
            cmd.Parameters.AddWithValue("@Descripcion", p.Descripcion);
            cmd.Parameters.AddWithValue("@idresponsable", p.Id_Responsable);
            cmd.Parameters.AddWithValue("@idusuario", p.Id_Usuario);
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

        public void ActualizarAccesoApp(AccesosApp p)
        {
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_ActualizarAccesoApp", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idAccesoApp", p.Id_AccesoApp);
            cmd.Parameters.AddWithValue("@idresponsable", p.Id_Responsable);

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



        public AccesosApp BuscarAccesoApp(int id)
        {
            AccesosApp accesoapp = null;
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_BuscarAccesoApp", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idAccesoApp", id);

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    accesoapp = new AccesosApp()
                    {

                        Id_AccesoApp = dr.GetInt32(0),
                        Id_Equipo = dr.GetInt32(1),
                        Id_Solicitud = dr.GetInt32(2),
                        Estado = dr.GetString(3),
                        tk_referencia = dr.GetString(4),
                        Descripcion = dr.GetString(5),
                        Id_Responsable = dr.GetInt32(6),
                        Id_Usuario = dr.GetInt32(7)
                    };
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return accesoapp;
        }

        public void EliminiarAccesoApp(AccesosApp p)
        {
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_EliminarAccesoApp", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idAccesoApp", p.Id_AccesoApp);

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

        public void InsertarAccesoApp(AccesosApp p)
        {
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_InsertarAccesoApp", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idequipo", p.Id_Equipo);
            cmd.Parameters.AddWithValue("@idsolicitud", p.Id_Solicitud);
            cmd.Parameters.AddWithValue("@tk_referencia", p.tk_referencia);
            cmd.Parameters.AddWithValue("@Descripcion", p.Descripcion);
            cmd.Parameters.AddWithValue("@idusuario", p.Id_Usuario);


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

        public List<AccesosApp> ListarAccesoAppDal()
        {
            List<AccesosApp> lista = new List<AccesosApp>();
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_ListarAccesoApp", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    AccesosApp p = new AccesosApp()
                    {

                        Id_AccesoApp = dr.GetInt32(0),
                        Equipo = dr.GetString(1),
                        Solicitud = dr.GetString(2),
                        Estado = dr.GetString(3),
                        tk_referencia = dr.GetString(4),
                        Descripcion = dr.GetString(5),
                        Responsable = dr.GetString(6),
                        Usuario = dr.GetString(7)
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


        public AccesosApp BuscarEquipoxUsuario(int id)
        {
            AccesosApp accesosApp = null;
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_BuscarEquipoxUsuario", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IDUSUARIO", id);

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    accesosApp = new AccesosApp()
                    {

                        Id_Equipo = dr.GetInt32(0),
                        Equipo = dr.GetString(1)
                    };
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return accesosApp;
        }

        public AccesosApp BuscarSolicitantexUsuario(int id)
        {
            AccesosApp accesosApp = null;
            SqlConnection cn = bd.ConectarBD();
            SqlCommand cmd = new SqlCommand("SP_BuscarSolicitantexUsuario", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IDUSUARIO", id);

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    accesosApp = new AccesosApp()
                    {

                        Id_Solicitante = dr.GetInt32(0),
                        Solicitante = dr.GetString(1)
                    };
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return accesosApp;
        }

    
    }
}
