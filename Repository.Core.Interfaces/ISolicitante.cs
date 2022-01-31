using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core.Interfaces
{
    public interface ISolicitante<T>
    {
        List<T> ListarSolicitanteDal();
        List<T> ListarcboSolicitanteDal();



    }
}
