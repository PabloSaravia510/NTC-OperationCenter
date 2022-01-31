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
    public class TipoPaseManager : ITipoPase<TipoPase>
    {
        TipoPaseDal objTpPase = new TipoPaseDal();

        public void ActualizarTpPase(TipoPase p)
        {
            objTpPase.ActualizarTpPase(p);
        }

        public TipoPase BuscarTpPase(int id)
        {
            return objTpPase.BuscarTpPase(id);
        }

        public void EliminarTpPase(TipoPase p)
        {
            objTpPase.EliminarTpPase(p);
        }

        public void InsertarTpPase(TipoPase p)
        {
            objTpPase.InsertarTpPase(p);
        }

        public List<TipoPase> ListarTpPaseDal()
        {
            return objTpPase.ListarTpPaseDal().ToList();
        }
    }
}
