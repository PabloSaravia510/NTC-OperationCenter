using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Interface
{
    public interface ISolicitante<T>
    {
        List<T> ListarSolicitante();
        List<T> ListarcboSolicitanteDal();

    }
}
