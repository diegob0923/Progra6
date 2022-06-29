using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class AdiccionesController : Controller
    {
        ProyectoSegurosEntities modeloBD = new ProyectoSegurosEntities();

        public ActionResult AdiccionesLista()
        {
            List<sp_Retorna_Adicciones_Result> modeloVista = new List<sp_Retorna_Adicciones_Result>();
            modeloVista = modeloBD.sp_Retorna_Adicciones(null,null).ToList();
            return View(modeloVista);
        }
    }
}