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
    public class EquipoManager: IEquipo<Equipo>
    {
        EquipoDal objequipo = new EquipoDal();

        public void ActualizarEquipo(Equipo p)
        {
            objequipo.ActualizarEquipo(p);
        }

        public Equipo BuscarEquipo(int id)
        {
            return objequipo.BuscarEquipo(id);
        }

        public void EliminaEquipo(Equipo p)
        {
            objequipo.EliminaEquipo(p);
        }

        public void InsertEquipo(Equipo p)
        {
            objequipo.InsertEquipo(p);
        }

        public List<Equipo> ListarEquipo()
        {
            return objequipo.ListEquipoDAL();
        }

   
    }
}
