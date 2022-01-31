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
    public class TipoGAManager : ITipoGA<TipoGA>
    {
        TipoGADal objtipoGA = new TipoGADal();

        public void ActualizarTipoGA(TipoGA p)
        {
            objtipoGA.ActualizarTipoGA(p);
        }

        public TipoGA BuscarTipoGA(int id)
        {
            return objtipoGA.BuscarTipoGA(id);
        }

        public void EliminarTipoGA(TipoGA p)
        {
            objtipoGA.EliminarTipoGA(p);
        }

        public void InsertTipoGA(TipoGA p)
        {
            objtipoGA.InsertTipoGA(p);
        }

        public List<TipoGA> ListaTipoGA()
        {
            return objtipoGA.ListaTipoGA().ToList();
        }
    }
}
