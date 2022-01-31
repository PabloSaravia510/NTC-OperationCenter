using Repository.Core.Entity.GestionAccesos;
using Repository.Core.Models.GestionAccesosDal;
using Service.Core.Interface.IGestionAccesos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.MainModule.GestionAccesosManager
{
    public class GestionAccesoManager : IGestionAcceso<GestionAcceso>
    {
        GestionAccesoDal objgestionacceso = new GestionAccesoDal();

        public void ActualizarGestionAcceso(GestionAcceso p)
        {
            objgestionacceso.ActualizarGestionAcceso(p);
        }

        public GestionAcceso BuscarGestionAcceso(int id)
        {
            return objgestionacceso.BuscarGestionAcceso(id);
        }

        public void EliminarGestionAcceso(GestionAcceso p)
        {
            objgestionacceso.EliminarGestionAcceso(p);
        }

        public void InsertGestionAcceso(GestionAcceso p)
        {
            objgestionacceso.InsertGestionAcceso(p);
        }

        public List<GestionAcceso> ListaGestionAcceso()
        {
            return objgestionacceso.ListaGestionAcceso().ToList();
        }
    }
}
