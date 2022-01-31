using NTC_OperCenter.Models.ViewModels;
using Repository.Core.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTC_OperCenter.Controllers
{
    public class PaseProduccionDetController : Controller
    {
        // GET: PaseProduccionDet
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult DetPaseProduccion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DetPaseProduccion(PasesProduccionViewModel model)
        {
            try
            {
                using (NTC_OperationCenterEntities db = new NTC_OperationCenterEntities())
                {
                    TB_SERVIDOR_DEV objservidordev = new TB_SERVIDOR_DEV();
                    objservidordev.Descripcion = model.ServidorDevDescripcion;
                    db.TB_SERVIDOR_DEV.Add(objservidordev);
                    db.SaveChanges();

                    TB_TIPO_OBJ objtipoobj = new TB_TIPO_OBJ();
                    objtipoobj.Descripcion = model.TipoObjetoDescripcion;
                    db.TB_TIPO_OBJ.Add(objtipoobj);
                    db.SaveChanges();

                    TB_PROYECTO objproyecto = new TB_PROYECTO();
                    objproyecto.Descripcion = model.ProyectoDescripcion;
                    db.TB_PROYECTO.Add(objproyecto);
                    db.SaveChanges();

                    TB_RUTA_PASE objrutapase = new TB_RUTA_PASE();
                    objrutapase.Descripcion = model.RutaPasesDescripcion;
                    db.TB_RUTA_PASE.Add(objrutapase);
                    db.SaveChanges();

                    foreach(var objdetalle in model.detalles)
                    {
                        TB_DETALLE_PASES_PRODUCCION oDetalles = new TB_DETALLE_PASES_PRODUCCION();
                        oDetalles.Servidor_Dest = objdetalle.Servidor_Dest;
                        oDetalles.Id_ServidorDev = objservidordev.Id_ServidorDev;
                        oDetalles.Id_TpObj = objtipoobj.Id_TpObj;
                        oDetalles.Id_Proyecto = objproyecto.Id_Proyecto;
                        oDetalles.Id_RT_Pase = objrutapase.Id_RT_Pase;
                        db.TB_DETALLE_PASES_PRODUCCION.Add(oDetalles);
                    }

                    db.SaveChanges();

                }

                return View();


            }catch(Exception ex){
                return View(model);
            }

        }




    }
}