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
    public class SolicitanteGAController : Controller
    {
        SolicitanteGAManager objsolicitanteGA = new SolicitanteGAManager();


        //INDEX
        public ActionResult ListarSolicitanteGA()
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

                List<SolicitanteGA> listSolicitanteGA = objsolicitanteGA.ListaSolicitanteGA().ToList();
                return Json(new { data = listSolicitanteGA }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { data = "[]" }, JsonRequestBehavior.AllowGet);
            }
        }



        //BUSCAR
        public JsonResult BuscarSolicitanteGA(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                SolicitanteGA user = objsolicitanteGA.BuscarSolicitanteGA(id);
                return Json(user, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("[]", JsonRequestBehavior.AllowGet);
            }


        }



        //GUARDAR
        [HttpPost]
        public JsonResult GuardarSolicitanteGA(SolicitanteGA solicitanteGA)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                bool respuesta = true;
                try
                {
                    if (solicitanteGA.Id_Solicitante_GA == 0)
                    {
                        objsolicitanteGA.InsertSolicitanteGA(solicitanteGA);
                    }
                    else
                    {
                        objsolicitanteGA.ActualizarSolicitanteGA(solicitanteGA);
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
        public JsonResult DeleteSolicitanteGA(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                bool respuesta = true;
                try
                {
                    SolicitanteGA solicitanteGA = objsolicitanteGA.BuscarSolicitanteGA(id);
                    objsolicitanteGA.EliminarSolicitanteGA(solicitanteGA);
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