using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Test_GISSA.Entidades;
using WebApplication28.DAO;

namespace WebApplication28.Controllers
{
    public class HomeController : Controller
    {
        test_Habilidades_UsuarioDAO dao_Habilidades_Usuario = new test_Habilidades_UsuarioDAO();
        test_TelefonoDAO dao_telefono = new test_TelefonoDAO();
        public ActionResult Index()
        {
            ViewBag.Tittle = Session["User"];
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public JsonResult Telefonos(string fk_usuario)
        {
           List<test_Telefono> list= dao_telefono.Listar_Telefonos(Int32.Parse(fk_usuario));

            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Habilidades(string fk_usuario)
        {
            List<test_Habilidades_Usuario> list = dao_Habilidades_Usuario.Listar_Habilidades(Int32.Parse(fk_usuario));

            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Lista_Usuario()
        {
           


            return View();
        }
        public ActionResult Editar(string fk_usuario)
        {
            test_UsuarioDAO dao = new test_UsuarioDAO();
           test_Usuario model = dao.Buscar_Usuario(Int32.Parse(fk_usuario) );
            ViewData["FK"] = fk_usuario;
            Session["FK_User"] = fk_usuario;
            
            return View(model);
        }
        public ActionResult Crear()
        {
            
            return View();
        }
        public ActionResult Eliminar(string fk_usuario)
        {
            test_UsuarioDAO dao = new test_UsuarioDAO();
           
            dao_Habilidades_Usuario.Eliminar_Telefono(Int32.Parse(fk_usuario));
            dao_telefono.Eliminar_Telefono(Int32.Parse(fk_usuario));
            dao.Eliminar_Usuario(Int32.Parse(fk_usuario));

            return Redirect("/Home/Lista_Usuario");
        }

        [HttpGet]
        public JsonResult List()
        {
            test_UsuarioDAO dao = new test_UsuarioDAO();
            List<test_Usuario> list_usuarios = dao.Listar_Usuario();
           
            return Json(list_usuarios, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public int Ingresa_Usuario(FormCollection collection)
        {
            try
            {
                test_UsuarioDAO dao_usuario = new test_UsuarioDAO();
                


                int res = dao_usuario.Insertar_Usuario(new test_Usuario(
                   collection["Cedula"].Trim(),
                   collection["Tipo_Usuario"].Trim(),
                   collection["Tipo_Identificacion"].Trim(),
                   collection["Nombre"].Trim(),
                   collection["Nombre_Usuario"].Trim(),
                   collection["Clave"].Trim(),
                   collection["Correo"].Trim()));

                return res;
               
            }
            catch
            {
                return 0;
            }
        }


        [HttpPost]
        public int Edita_Usuario(FormCollection collection)
        {
            try
            {
                test_UsuarioDAO dao_usuario = new test_UsuarioDAO();
                string aux2 = Session["FK_User"].ToString();
                int aux = Int32.Parse(aux2);

                int res = dao_usuario.Editar_Usuario(new test_Usuario(
                   aux,
                   collection["Cedula"].Trim(),
                   collection["Tipo_Usuario"].Trim(),
                   collection["Tipo_Identificacion"].Trim(),
                   collection["Nombre"].Trim(),
                   collection["Nombre_Usuario"].Trim(),
                   collection["Clave"].Trim(),
                   collection["Correo"].Trim()));

                return aux;

            }
            catch
            {
                return 0;
            }
        }
        [HttpPost]
        public ActionResult Ingresa(List<string> telefonos, List<string> habilidades, List<string> fk_usuario)
        {
            try
            {
                
                test_TelefonoDAO dao_telefono = new test_TelefonoDAO();
                

                dao_telefono.Insertar_Telefonos(telefonos,fk_usuario[0]);
                dao_Habilidades_Usuario.Insertar_Habilidades(habilidades, fk_usuario[0]);

                return RedirectToAction("Lista_Usuario");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edita(List<string> telefonos, List<string> habilidades, List<string> fk_usuario)
        {
            try
            {

                dao_telefono.Eliminar_Telefono(Int32.Parse(fk_usuario[0]));
                dao_Habilidades_Usuario.Eliminar_Telefono(Int32.Parse(fk_usuario[0]));

                dao_telefono.Insertar_Telefonos(telefonos, fk_usuario[0]);
                dao_Habilidades_Usuario.Insertar_Habilidades(habilidades, fk_usuario[0]);
                
                return RedirectToAction("Lista_Usuario");
            }
            catch
            {
                return View();
            }
        }
    }
}