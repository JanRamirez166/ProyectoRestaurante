using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class RestauranteController : Controller
    {
        // GET: Restaurante
        public ActionResult Restaurantes()
        {
            return View();
        }

        public ActionResult Formulario() 
        {
            ML.Restaurante restaurante = new ML.Restaurante();

            return View(restaurante);
        }

        [HttpPost]
        public ActionResult Formulario(ML.Restaurante restaurante, HttpPostedFileBase Imagen) 
        {

            return View(restaurante);
        }
           
    }
}