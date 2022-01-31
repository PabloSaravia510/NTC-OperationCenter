using Repository.Core.Entity;
using Service.Core.MainModule;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTC_OperCenter.Controllers
{
    public class ProveedorController : Controller
    {
        ProveedorManager objproveedor = new ProveedorManager();

        //INDEX
        public ActionResult ListarProveedor()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }




        //LIST
        public JsonResult GetData()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                List<Proveedor> listProveedor = objproveedor.ListarProveedorDal().ToList();
                return Json(new { data = listProveedor }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { data = "[]" }, JsonRequestBehavior.AllowGet);
            }
        }



        //BUSCAR
        public JsonResult BuscarAproveedor(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                Proveedor user = objproveedor.BuscarProveedor(id);
                return Json(user, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("[]", JsonRequestBehavior.AllowGet);
            }


        }




        //GUARDAR
        [HttpPost]
        public JsonResult GuardarProveedor(Proveedor proveedor)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                bool respuesta = true;
                try
                {
                    if (proveedor.Id_Proveedor == 0)
                    {
                        objproveedor.InsertarProveedor(proveedor);
                    }
                    else
                    {
                        objproveedor.ActualizarProveedor(proveedor);
                    }
                }
                catch (SqlException ex)
                {
                    respuesta = false;
                }

                return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { resultado = "[]" }, JsonRequestBehavior.AllowGet);
            }

        }




        //ELIMINAR
        public JsonResult DeleteProveedor(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                bool respuesta = true;
                try
                {
                    Proveedor proveedor = objproveedor.BuscarProveedor(id);
                    objproveedor.EliminarProveedor(proveedor);
                }
                catch (SqlException ex)
                {
                    respuesta = false;
                }

                return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { resultado = "[]" }, JsonRequestBehavior.AllowGet);
            }
        }




    }
}