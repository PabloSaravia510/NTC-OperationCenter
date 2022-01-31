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
    public class AccesoAppController : Controller
    {
        AccesoAppManager objaccesoApp = new AccesoAppManager();
        EquipoManager objequipoManager = new EquipoManager();
        SolicitanteManager objsolicitanteManager = new SolicitanteManager();
        SolicitudManager objsolicitudManager = new SolicitudManager();
        ResponsableManager objresponsableManager = new ResponsableManager();



        //INDEX
        public ActionResult ListarAccesosApp()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];
                ViewBag.Usuario = Session["IdUsuario"];

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
                ViewBag.Usuario = Session["IdUsuario"];

                List<AccesosApp> listsri = objaccesoApp.ListarAccesoAppDal().ToList();
                return Json(new { data = listsri }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { data = "[]" }, JsonRequestBehavior.AllowGet);
            }
        }


        //BUSCAR
        public JsonResult BuscarSRI(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];
                ViewBag.Usuario = Session["IdUsuario"];

                AccesosApp user = objaccesoApp.BuscarAccesoApp(id);
                return Json(user, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("[]", JsonRequestBehavior.AllowGet);
            }


        }


        //COMBO EQUIPOXUSUARIO
        public JsonResult ListarEquipoxUsuario(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];
                ViewBag.Usuario = Session["IdUsuario"];

                AccesosApp equipo = objaccesoApp.BuscarEquipoxUsuario(id);
                return Json(equipo, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("[]", JsonRequestBehavior.AllowGet);
            }

        }

        //COMBO EQUIPO
        public JsonResult ListarEquipo()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];
                ViewBag.Usuario = Session["IdUsuario"];

                List<Equipo> equipo = objequipoManager.ListarEquipo();
                return Json(equipo, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("[]", JsonRequestBehavior.AllowGet);
            }

        }

        //COMBO SOLICITANTE
        public JsonResult ListarSolicitante()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];
                ViewBag.Usuario = Session["IdUsuario"];

                List<Solicitante> solicitantes = objsolicitanteManager.ListarcboSolicitanteDal();
                return Json(solicitantes, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("[]", JsonRequestBehavior.AllowGet);
            }

        }


        //COMBO SOLICITANTEXUSUARIO
        public JsonResult ListarSolicitantexUsuario(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];
                ViewBag.Usuario = Session["IdUsuario"];

                AccesosApp solicitantes = objaccesoApp.BuscarSolicitantexUsuario(id);
                return Json(solicitantes, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("[]", JsonRequestBehavior.AllowGet);
            }

        }


        //COMBO SOLICITUD
        public JsonResult ListarSolicitud()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];
                ViewBag.Usuario = Session["IdUsuario"];

                List<Solicitud> solicitud = objsolicitudManager.ListarSolcitudDal();
                return Json(solicitud, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("[]", JsonRequestBehavior.AllowGet);
            }

        }



        //COMBO RESPONSABLE
        public JsonResult ListarResponsable()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];
                ViewBag.Usuario = Session["IdUsuario"];

                List<Responsable> responsable = objresponsableManager.ListarResponsable();
                return Json(responsable, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("[]", JsonRequestBehavior.AllowGet);
            }

        }


        //GUARDAR
        [HttpPost]
        public JsonResult GuardarSRI(AccesosApp accesosapp)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];
                ViewBag.Usuario = Session["IdUsuario"];

                bool respuesta = true;
                try
                {
                    if (accesosapp.Id_AccesoApp == 0)
                    {
                        objaccesoApp.InsertarAccesoApp(accesosapp);
                    }
                    else
                    {
                        if(ViewBag.Categoria == 1)
                        {
                            objaccesoApp.ActualizarAccesoAppAdmin(accesosapp);
                        }
                        else
                        {
                            objaccesoApp.ActualizarAccesoApp(accesosapp);
                        }
                        
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
        public JsonResult DeleteSRI(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];
                ViewBag.Usuario = Session["IdUsuario"];

                bool respuesta = true;
                try
                {
                    AccesosApp accesosApp = objaccesoApp.BuscarAccesoApp(id);
                    objaccesoApp.EliminiarAccesoApp(accesosApp);
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