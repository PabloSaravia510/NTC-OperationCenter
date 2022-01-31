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
    public class AprobadoresGAManager : IAprobadoresGA<AprobadoresGA>
    {
        AprobadoresGADal objaprobadoresGA = new AprobadoresGADal();

        public void ActualizarAprobadoresGA(AprobadoresGA p)
        {
            objaprobadoresGA.ActualizarAprobadoresGA(p);
        }

        public AprobadoresGA BuscarAprobadoresGA(int id)
        {
            return objaprobadoresGA.BuscarAprobadoresGA(id);
        }

        public void EliminarAprobadoresGA(AprobadoresGA p)
        {
            objaprobadoresGA.EliminarAprobadoresGA(p);
        }

        public void InsertAprobadoresGA(AprobadoresGA p)
        {
            objaprobadoresGA.InsertAprobadoresGA(p);
        }

        public List<AprobadoresGA> ListaAprobadoresGA()
        {
            return objaprobadoresGA.ListaAprobadoresGA().ToList();
        }
    }
}
