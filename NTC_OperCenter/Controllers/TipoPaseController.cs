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
    public class TipoPaseController : Controller
    {
        TipoPaseManager objTpPase = new TipoPaseManager();

        //LIST
        public ActionResult ListarTipoPase()
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

                List<TipoPase> listTppase = objTpPase.ListarTpPaseDal().ToList();
                return Json(new { data = listTppase }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { data = "[]" }, JsonRequestBehavior.AllowGet);
            }
        }





        //BUSCAR
        public JsonResult BuscarTipoPase(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                TipoPase user = objTpPase.BuscarTpPase(id);
                return Json(user, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("[]", JsonRequestBehavior.AllowGet);
            }


        }



        //GUARDAR
        [HttpPost]
        public JsonResult GuardarTipoPase(TipoPase tipoPase)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                bool respuesta = true;
                try
                {
                    if (tipoPase.Id_TpPase == 0)
                    {
                        objTpPase.InsertarTpPase(tipoPase);
                    }
                    else
                    {
                        objTpPase.ActualizarTpPase(tipoPase);
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
        public JsonResult DeleteTipoPase(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                bool respuesta = true;
                try
                {
                    TipoPase tipoPase = objTpPase.BuscarTpPase(id);
                    objTpPase.EliminarTpPase(tipoPase);
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