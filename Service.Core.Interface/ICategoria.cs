using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Interface
{
   public interface ICategoria<T>
    {
        List<T> ListarCategoria();
    }
}
