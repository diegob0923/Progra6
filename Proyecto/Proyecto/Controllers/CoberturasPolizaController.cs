using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class CoberturasPolizaController : Controller
    {
        //Instancia del modelo de la base de datos
        ProyectoSegurosEntities modeloBD = new ProyectoSegurosEntities();

        // GET: CoberturasPoliza
        public ActionResult CoberturasPolizaLista()
        {
           
            return View();
        }
    }
}