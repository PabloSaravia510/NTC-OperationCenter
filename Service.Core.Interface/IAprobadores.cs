using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Interface
{
    public interface IAprobadores<T>
    {
        List<T> ListaAprobadores(); 
        void InsertAprobadores(T p);
        void ActualizarAprobadores(T p);
        void EliminarAprobadores(T p);

        T BuscarAprobadores(int id);
    }
}
