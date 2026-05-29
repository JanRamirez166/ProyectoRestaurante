using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class RestauranteController : Controller
    {
        // GET: Restaurante
        [HttpGet]
        public ActionResult Restaurantes()
        {
            ML.Restaurante restaurante = new ML.Restaurante();
            ML.Result resultGetAll = BL.Restaurante.GetAll();
            restaurante.Restaurantes = resultGetAll.Objects;
            return View(restaurante);
        }
        [HttpGet]
        public ActionResult Delete(int idRestaurante)
        {
            ML.Result result = BL.Restaurante.Delete(idRestaurante);
            if (!result.Correct) ViewBag.ErrorDelete("No se elimino el registro");
                return RedirectToAction("Restaurantes");
        }
        [HttpGet]
        public ActionResult Formulario(int? idRestaurante) 
        {
            ML.Restaurante restaurante = new ML.Restaurante();
            if (idRestaurante != null) {
                ML.Result result = BL.Restaurante.GetById(idRestaurante.Value);
                if(result.Correct)restaurante=(ML.Restaurante)result.Object;
            }
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