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
    public class AprobadoresManager : IAprobadores<Aprobadores>
    {
        AprobadoresDal objAprobador = new AprobadoresDal();

        public void ActualizarAprobadores(Aprobadores p)
        {
            objAprobador.ActualizarAprobadores(p);
        }

        public Aprobadores BuscarAprobadores(int id)
        {
            return objAprobador.BuscarAprobadores(id);
        }

        public void EliminarAprobadores(Aprobadores p)
        {
            objAprobador.EliminarAprobadores(p);
        }

        public void InsertAprobadores(Aprobadores p)
        {
            objAprobador.InsertAprobadores(p);
        }

        public List<Aprobadores> ListaAprobadores()
        {
            return objAprobador.ListaAprobadores();
        }
    }
}
