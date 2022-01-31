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
    public class ResponsableManager : IResponsable<Responsable>
    {
        ResponsableDal objresponsable = new ResponsableDal();
        public void ActualizarResponsable(Responsable p)
        {
            objresponsable.ActualizarResponsable(p);
        }

        public Responsable BuscarResponsable(int id)
        {
            return objresponsable.BuscarResponsable(id);
        }

        public void EliminarResponsable(Responsable p)
        {
            objresponsable.EliminarResponsable(p);
        }

        public void InsertarResponsable(Responsable p)
        {
            objresponsable.InsertarResponsable(p);
        }

        public List<Responsable> ListarResponsable()
        {
           return objresponsable.ListarResponsableDal().ToList();
        }
    }
}
