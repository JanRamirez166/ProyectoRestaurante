using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult Formulario(ML.Restaurante restaurante, HttpPostedFileBase ImagenRestauranteEnviada) 
        {
            if (ImagenRestauranteEnviada != null)
            {
                using (Stream inputStream = ImagenRestauranteEnviada.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    restaurante.Imagen = memoryStream.ToArray();
                }
            }


            return View(restaurante);
        }
           
    }
}