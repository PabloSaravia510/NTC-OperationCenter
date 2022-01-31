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
    public class AreaGAManager : IAreaGA<AreaGA>
    {
        AreaGADal objareaga = new AreaGADal();

        public void ActualizarAreaGA(AreaGA p)
        {
            objareaga.ActualizarAreaGA(p);
        }

        public AreaGA BuscarAreaGA(int id)
        {
            return objareaga.BuscarAreaGA(id);
        }

        public void EliminarAreaGA(AreaGA p)
        {
            objareaga.EliminarAreaGA(p);
        }

        public void InsertAreaGA(AreaGA p)
        {
            objareaga.InsertAreaGA(p);
        }

        public List<AreaGA> ListaAreaGA()
        {
            return objareaga.ListaAreaGA().ToList();
        }
    }
}
