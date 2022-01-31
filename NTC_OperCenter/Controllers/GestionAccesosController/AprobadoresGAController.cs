
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
    public class AprobadoresGAController : Controller
    {
        AprobadoresGAManager objaprobadoresGA = new AprobadoresGAManager();

        //INDEX
        public ActionResult ListarAprobadoresGA()
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

                List<AprobadoresGA> listAprobadoresGA = objaprobadoresGA.ListaAprobadoresGA().ToList();
                return Json(new { data = listAprobadoresGA }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { data = "[]" }, JsonRequestBehavior.AllowGet);
            }
        }


        //BUSCAR
        public JsonResult BuscarAprobadoresGA(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                AprobadoresGA user = objaprobadoresGA.BuscarAprobadoresGA(id);
                return Json(user, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("[]", JsonRequestBehavior.AllowGet);
            }


        }



        //GUARDAR
        [HttpPost]
        public JsonResult GuardarAprobadoresGA(AprobadoresGA aprobadoresGA)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                bool respuesta = true;
                try
                {
                    if (aprobadoresGA.Id_Aprobadores_GA == 0)
                    {
                        objaprobadoresGA.InsertAprobadoresGA(aprobadoresGA);
                    }
                    else
                    {
                        objaprobadoresGA.ActualizarAprobadoresGA(aprobadoresGA);
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
        public JsonResult DeleteAprobadoresGA(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                bool respuesta = true;
                try
                {
                    AprobadoresGA aprobadoresGA = objaprobadoresGA.BuscarAprobadoresGA(id);
                    objaprobadoresGA.EliminarAprobadoresGA(aprobadoresGA);
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