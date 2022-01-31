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
    public class SolicitanteManager : ISolicitante<Solicitante>
    {
        SolicitanteDal objsolicitante = new SolicitanteDal();

        public List<Solicitante> ListarcboSolicitanteDal()
        {
            return objsolicitante.ListarcboSolicitanteDal();
        }

        public List<Solicitante> ListarSolicitante()
        {
            return objsolicitante.ListarSolicitanteDal();
        }
    }
}
