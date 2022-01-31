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
    public class SolicitudController : Controller
    {
        SolicitudManager objSolicitud = new SolicitudManager();


        //INDEX
        public ActionResult ListarSolicitud()
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

                List<Solicitud> listSolicitud = objSolicitud.ListarSolcitudDal().ToList();
                return Json(new { data = listSolicitud }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { data = "[]" }, JsonRequestBehavior.AllowGet);
            }
        }



        //BUSCAR
        public JsonResult BuscarSolicitud(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                Solicitud user = objSolicitud.BuscarSolicitud(id);
                return Json(user, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("[]", JsonRequestBehavior.AllowGet);
            }


        }




        //GUARDAR
        [HttpPost]
        public JsonResult GuardarSolicitud(Solicitud solicitud)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                bool respuesta = true;
                try
                {
                    if (solicitud.Id_Solicitud == 0)
                    {
                        objSolicitud.InsertarSolicitud(solicitud);
                    }
                    else
                    {
                        objSolicitud.ActualizarSolicitud(solicitud);
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
        public JsonResult DeleteSolicitud(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                bool respuesta = true;
                try
                {
                    Solicitud solicitud = objSolicitud.BuscarSolicitud(id);
                    objSolicitud.EliminarSolicitud(solicitud);
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