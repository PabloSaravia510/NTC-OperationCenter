using Service.Core.MainModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NTC_OperCenter.Controllers
{
    public class LoginController : Controller
    {
        UsuarioManager objusuario = new UsuarioManager();

        public ActionResult Index(int param1 = 0)
        {

            if (param1 == 1)
            {
                ViewBag.Mensaje = "Debe ingresar usuario y contraseña";
            }
            else if (param1 == 2)
            {
                ViewBag.Mensaje = "Debe ingresar usuario";
            }
            else if (param1 == 3)
            {
                ViewBag.Mensaje = "Debe ingresar contraseña";
            }
            else if (param1 == 4)
            {
                ViewBag.Mensaje = "Credenciales incorrectas";
            }
            else if (param1 == 5)
            {
                ViewBag.Mensaje = "Llena los campos para poder iniciar session";
            }

            return View("Login");
        }


        [HttpPost]
        public ActionResult Login(string username, string pwd)
        {

            if (username == "" && pwd == "")
            {
                return RedirectToAction("Index", "Login", new { param1 = 1 });

            }

            if (username == "")
            {
                return RedirectToAction("Index", "Login", new { param1 = 2 });

            }

            if (pwd == "")
            {
                return RedirectToAction("Index", "Login", new { param1 = 3 });

            }


            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(pwd))
            {
                var user = objusuario.LogIn(username, pwd);
                if(user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, true);
                    Session["User"] = user.Username.ToString();
                    Session["Pwd"] = user.Password.ToString();
                    Session["FirstName"] = user.Nombres.ToString();
                    Session["LastName"] = user.Apellidos.ToString();
                    Session["Categoria"] = user.Id_Categoria;
                    Session["IdUsuario"] = user.Id_Usuario;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Login", new { param1 = 4 });

                }
            }
            else
            {
                return RedirectToAction("Index", "Login", new { param1 = 5 });
            }
        }


        [Authorize]
        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Login");
        }


    }
}