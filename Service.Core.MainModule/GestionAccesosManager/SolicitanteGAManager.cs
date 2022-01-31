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
    public class SolicitanteGAManager : ISolicitanteGA<SolicitanteGA>
    {
        SolicitanteGADal objsolicitanteGA = new SolicitanteGADal();

        public void ActualizarSolicitanteGA(SolicitanteGA p)
        {
            objsolicitanteGA.ActualizarSolicitanteGA(p);
        }

        public SolicitanteGA BuscarSolicitanteGA(int id)
        {
            return objsolicitanteGA.BuscarSolicitanteGA(id);
        }

        public void EliminarSolicitanteGA(SolicitanteGA p)
        {
            objsolicitanteGA.EliminarSolicitanteGA(p);
        }

        public void InsertSolicitanteGA(SolicitanteGA p)
        {
            objsolicitanteGA.InsertSolicitanteGA(p);
        }

        public List<SolicitanteGA> ListaSolicitanteGA()
        {
            return objsolicitanteGA.ListaSolicitanteGA().ToList();
        }
    }
}
