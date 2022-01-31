using Repository.Core.Entity;
using Repository.Core.Entity.GestionAccesos;
using Service.Core.MainModule;
using Service.Core.MainModule.GestionAccesosManager;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTC_OperCenter.Controllers.GestionAccesosController
{
    public class GestionAccesoController : Controller
    {
        GestionAccesoManager objgestionacceso = new GestionAccesoManager();
        SolicitanteGAManager objsolicitanteGA = new SolicitanteGAManager();
        AreaGAManager objareaGA = new AreaGAManager();
        SedeGAManager objsedeGA = new SedeGAManager();
        ServicioGAManager objservicioGA = new ServicioGAManager();
        AprobadoresGAManager objaprobadoresGA = new AprobadoresGAManager();
        TipoGAManager objtipoGA = new TipoGAManager();
        ResponsableManager objresponsable = new ResponsableManager();

        //INDEX
        public ActionResult ListarGestionAcceso()
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

                List<GestionAcceso> listGestionAcceso = objgestionacceso.ListaGestionAcceso().ToList();
                return Json(new { data = listGestionAcceso }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { data = "[]" }, JsonRequestBehavior.AllowGet);
            }
        }


        //BUSCAR
        public JsonResult BuscarGestionAcceso(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                GestionAcceso user = objgestionacceso.BuscarGestionAcceso(id);
                return Json(user, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("[]", JsonRequestBehavior.AllowGet);
            }


        }



        //COMBO SOLICITANTE
        public JsonResult ListarSolicitanteGA()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];
                ViewBag.Usuario = Session["IdUsuario"];

                List<SolicitanteGA> solicitanteGA = objsolicitanteGA.ListaSolicitanteGA();
                return Json(solicitanteGA, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("[]", JsonRequestBehavior.AllowGet);
            }

        }



        //COMBO AREA
        public JsonResult ListarAreaGA()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];
                ViewBag.Usuario = Session["IdUsuario"];

                List<AreaGA> AreaGA = objareaGA.ListaAreaGA();
                return Json(AreaGA, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("[]", JsonRequestBehavior.AllowGet);
            }

        }



        //COMBO SEDE
        public JsonResult ListarSedeGA()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];
                ViewBag.Usuario = Session["IdUsuario"];

                List<SedeGA> sedeGA = objsedeGA.ListaSedeGA();
                return Json(sedeGA, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("[]", JsonRequestBehavior.AllowGet);
            }

        }


        //COMBO SERVICIO
        public JsonResult ListarServicioGA()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];
                ViewBag.Usuario = Session["IdUsuario"];

                List<ServicioGA> servicioGA = objservicioGA.ListaServicioGA();
                return Json(servicioGA, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("[]", JsonRequestBehavior.AllowGet);
            }

        }


        //COMBO APROBADORES
        public JsonResult ListarAprobadoresGA()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];
                ViewBag.Usuario = Session["IdUsuario"];

                List<AprobadoresGA> aprobadoresGA = objaprobadoresGA.ListaAprobadoresGA();
                return Json(aprobadoresGA, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("[]", JsonRequestBehavior.AllowGet);
            }

        }


        //COMBO TIPO
        public JsonResult ListarTipoGA()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];
                ViewBag.Usuario = Session["IdUsuario"];

                List<TipoGA> tipoGA = objtipoGA.ListaTipoGA();
                return Json(tipoGA, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("[]", JsonRequestBehavior.AllowGet);
            }

        }


        //COMBO RESPONSABLE
        public JsonResult ListarResponsableGA()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];
                ViewBag.Usuario = Session["IdUsuario"];

                List<Responsable> responsables = objresponsable.ListarResponsable();
                return Json(responsables, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("[]", JsonRequestBehavior.AllowGet);
            }

        }





        //GUARDAR
        [HttpPost]
        public JsonResult GuardarGestionAcceso(GestionAcceso gestionAcceso)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                bool respuesta = true;
                try
                {
                    if (gestionAcceso.Id_GestionAcceso == 0)
                    {
                        objgestionacceso.InsertGestionAcceso(gestionAcceso);
                    }
                    else
                    {
                        objgestionacceso.ActualizarGestionAcceso(gestionAcceso);
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
        public JsonResult DeleteGestionAcceso(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                bool respuesta = true;
                try
                {
                    GestionAcceso gestionAcceso = objgestionacceso.BuscarGestionAcceso(id);
                    objgestionacceso.EliminarGestionAcceso(gestionAcceso);
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