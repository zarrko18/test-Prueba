using System.Web.Mvc;
using Test_GISSA.Entidades;
using WebApplication28.DAO;

namespace WebApplication28.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            try
            {
                test_UsuarioDAO dao = new test_UsuarioDAO();

                string res = dao.consultausuarioperfil(new test_Usuario( collection["Nombre_Usuario"], collection["Clave"]));
                switch (res)
                {
                    case "administrador":
                        {
                            Session["User"] = res;
                            
                            return Redirect("/Home/Index");
                            
                        }
                    case "consultor":
                        {
                            Session["User"] = res;
                         
                            return Redirect("/Home/Index");

                        }
                   default:
                        {
                            //enviar error
                            return RedirectToAction("Index");

                        }

                }
            }
            catch
            {
                return View("Index");
            }
        }
    }
}
