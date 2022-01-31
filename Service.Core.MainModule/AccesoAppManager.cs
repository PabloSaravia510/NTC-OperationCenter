using Repository.Core.Entity;
using Repository.Core.Models;
using Service.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.MainModule
{
    public class AccesoAppManager : IAccesoApp<AccesosApp>
    {
        AccesoAppDal objaccesoApp = new AccesoAppDal();

        public void ActualizarAccesoApp(AccesosApp p)
        {
            objaccesoApp.ActualizarAccesoApp(p);
        }

        public void ActualizarAccesoAppAdmin(AccesosApp p)
        {
            objaccesoApp.ActualizarAccesoAppAdmin(p);
        }

        public AccesosApp BuscarAccesoApp(int id)
        {
            return objaccesoApp.BuscarAccesoApp(id);
        }

        public AccesosApp BuscarEquipoxUsuario(int id)
        {
            return objaccesoApp.BuscarEquipoxUsuario(id);
        }

        public AccesosApp BuscarSolicitantexUsuario(int id)
        {
            return objaccesoApp.BuscarSolicitantexUsuario(id);
        }

        public void EliminiarAccesoApp(AccesosApp p)
        {
            objaccesoApp.EliminiarAccesoApp(p);
        }

        public void InsertarAccesoApp(AccesosApp p)
        {
            objaccesoApp.InsertarAccesoApp(p);
        }

        public List<AccesosApp> ListarAccesoAppDal()
        {
            return objaccesoApp.ListarAccesoAppDal().ToList();
        }
    }
}
