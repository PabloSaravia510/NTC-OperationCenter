using Repository.Core.Entity.GestionAccesos;
using Service.Core.MainModule.GestionAccesosManager;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTC_OperCenter.Controllers.GestionAccesosController
{
    public class ServicioGAController : Controller
    {
        ServicioGAManager objservicioGA = new ServicioGAManager();

        //INDEX
        public ActionResult ListarServicioGA()
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

                List<ServicioGA> listServicioGA = objservicioGA.ListaServicioGA().ToList();
                return Json(new { data = listServicioGA }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { data = "[]" }, JsonRequestBehavior.AllowGet);
            }
        }



        //BUSCAR
        public JsonResult BuscarServicioGA(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                ServicioGA user = objservicioGA.BuscarServicioGA(id);
                return Json(user, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("[]", JsonRequestBehavior.AllowGet);
            }


        }



        //GUARDAR
        [HttpPost]
        public JsonResult GuardarServicioGA(ServicioGA servicioGA)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                bool respuesta = true;
                try
                {
                    if (servicioGA.Id_Servicio_GA == 0)
                    {
                        objservicioGA.InsertServicioGA(servicioGA);
                    }
                    else
                    {
                        objservicioGA.ActualizarServicioGA(servicioGA);
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
        public JsonResult DeleteServicioGA(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                bool respuesta = true;
                try
                {
                    ServicioGA servicioGA = objservicioGA.BuscarServicioGA(id);
                    objservicioGA.EliminarServicioGA(servicioGA);
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