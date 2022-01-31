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
    public class ProveedorManager : IProveedor<Proveedor>
    {
        ProveedorDal objproveedor = new ProveedorDal();

        public void ActualizarProveedor(Proveedor p)
        {
            objproveedor.ActualizarProveedor(p);
        }

        public Proveedor BuscarProveedor(int id)
        {
            return objproveedor.BuscarProveedor(id);
        }

        public void EliminarProveedor(Proveedor p)
        {
            objproveedor.EliminarProveedor(p);
        }

        public void InsertarProveedor(Proveedor p)
        {
            objproveedor.InsertarProveedor(p);
        }

        public List<Proveedor> ListarProveedorDal()
        {
            return objproveedor.ListarProveedorDal().ToList();
        }
    }
}
