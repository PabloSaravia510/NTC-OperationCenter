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
    public class ServicioGAManager : IServicioGA<ServicioGA>
    {
        ServicioGADal objservicioga = new ServicioGADal();

        public void ActualizarServicioGA(ServicioGA p)
        {
            objservicioga.ActualizarServicioGA(p);
        }

        public ServicioGA BuscarServicioGA(int id)
        {
            return objservicioga.BuscarServicioGA(id);
        }

        public void EliminarServicioGA(ServicioGA p)
        {
            objservicioga.EliminarServicioGA(p);
        }

        public void InsertServicioGA(ServicioGA p)
        {
            objservicioga.InsertServicioGA(p);
        }

        public List<ServicioGA> ListaServicioGA()
        {
            return objservicioga.ListaServicioGA().ToList();
        }
    }
}
