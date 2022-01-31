using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Interface
{
    public interface IAccesoApp<T>
    {
        List<T> ListarAccesoAppDal();
        void InsertarAccesoApp(T p);
        void ActualizarAccesoAppAdmin(T p);
        void ActualizarAccesoApp(T p);
        void EliminiarAccesoApp(T p);
        T BuscarAccesoApp(int id);
        T BuscarEquipoxUsuario(int id);
        T BuscarSolicitantexUsuario(int id);
    }
}
