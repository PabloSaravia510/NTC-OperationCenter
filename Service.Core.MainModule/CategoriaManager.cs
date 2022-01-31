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
    public class CategoriaManager : ICategoria<Categoria>
    {
        CategoriaDal objcategoria = new CategoriaDal();
        public List<Categoria> ListarCategoria()
        {
            return objcategoria.ListarCategoriaDal().ToList();
        }
    }
}
