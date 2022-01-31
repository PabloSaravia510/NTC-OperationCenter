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
    public class SedeGAManager : ISedeGA<SedeGA>
    {
        SedeGADal objsedega = new SedeGADal();
        public void ActualizarSedeGA(SedeGA p)
        {
            objsedega.ActualizarSedeGA(p);
        }

        public SedeGA BuscarSedeGA(int id)
        {
            return objsedega.BuscarSedeGA(id);
        }

        public void EliminarSedeGA(SedeGA p)
        {
            objsedega.EliminarSedeGA(p);
        }

        public void InsertSedeGA(SedeGA p)
        {
            objsedega.InsertSedeGA(p);
        }

        public List<SedeGA> ListaSedeGA()
        {
            return objsedega.ListaSedeGA().ToList();
        }
    }
}
