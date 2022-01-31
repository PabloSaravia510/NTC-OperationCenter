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
    public class SistemaManager : ISistema<Sistema>
    {
        SistemaDal objsistema = new SistemaDal();

        public void ActualizarSistema(Sistema p)
        {
            objsistema.ActualizarSistema(p);
        }

        public Sistema BuscarSistema(int id)
        {
            return objsistema.BuscarSistema(id);
        }

        public void EliminarSistema(Sistema p)
        {
            objsistema.EliminarSistema(p);
        }

        public void InsertarSistema(Sistema p)
        {
            objsistema.InsertarSistema(p);
        }

        public List<Sistema> ListarSistemaDal()
        {
            return objsistema.ListarSistemaDal().ToList();
        }
    }
}
