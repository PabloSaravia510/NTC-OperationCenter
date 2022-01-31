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
    public class UsuariosController : Controller
    {
        UsuarioManager objusuario = new UsuarioManager();
        CategoriaManager objcategoria = new CategoriaManager();
        EquipoManager objequipo = new EquipoManager();

        //INDEX
        public ActionResult ListarUsuario()
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

                List<Usuario> listUsuario = objusuario.ListarUsuariosDal().ToList();
                return Json(new { data = listUsuario }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { data = "[]" }, JsonRequestBehavior.AllowGet);
            }
        }





        //BUSCAR
        public JsonResult BuscarUsuarios(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                Usuario user = objusuario.BuscarUsuarios(id);
                return Json(user, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json( "[]" , JsonRequestBehavior.AllowGet);
            }
          
                   
        }




        //COMBO CATEGORIA
        public JsonResult ListarCategorias()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                List<Categoria> cate = objcategoria.ListarCategoria();
                return Json(cate, JsonRequestBehavior.AllowGet);
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

                List<Equipo> equipo = objequipo.ListarEquipo();
                return Json(equipo, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("[]", JsonRequestBehavior.AllowGet);
            }

        }






        //GUARDAR
        [HttpPost]
        public JsonResult GuardarUsuarios(Usuario usuario)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                bool respuesta = true;
                try
                {
                    if (usuario.Id_Usuario == 0)
                    {
                        objusuario.InsertaUsuarios(usuario);
                    }
                    else
                    {
                        objusuario.ActualizarUsuarios(usuario);
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
        public JsonResult DeleteUsuario(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Categoria = Session["Categoria"];

                bool respuesta = true;
                try
                {
                    Usuario usuario = objusuario.BuscarUsuarios(id);
                    objusuario.EliminarUsuarios(usuario);
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