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
    public class SolicitudManager : ISolicitud<Solicitud>
    {
        SolicitudDal objSolicitud = new SolicitudDal();
        public void ActualizarSolicitud(Solicitud p)
        {
            objSolicitud.ActualizarSolicitud(p);
        }

        public Solicitud BuscarSolicitud(int id)
        {
            return objSolicitud.BuscarSolicitud(id);
        }

        public void EliminarSolicitud(Solicitud p)
        {
            objSolicitud.EliminarSolicitud(p);
        }

        public void InsertarSolicitud(Solicitud p)
        {
            objSolicitud.InsertarSolicitud(p);
        }

        public List<Solicitud> ListarSolcitudDal()
        {
            return objSolicitud.ListarSolcitudDal().ToList();
        }
    }
}
