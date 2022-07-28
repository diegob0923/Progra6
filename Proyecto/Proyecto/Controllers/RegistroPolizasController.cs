using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class RegistroPolizasController : Controller
    {
        ProyectoSegurosEntities modeloBD = new ProyectoSegurosEntities();
        public ActionResult RegistroPolizasLista()
        {
            List<sp_Retorna_Poliza_Cliente_Result> modeloVista = new List<sp_Retorna_Poliza_Cliente_Result>();
            modeloVista = modeloBD.sp_Retorna_Poliza_Cliente(null, null).ToList();
            return View(modeloVista);
        }

        public ActionResult RegistroPolizasInsertar()
        {
            AgregarCoberturaViewBag();
            AgregarClientesViewBag();
            return View();
        }

        void AgregarCoberturaViewBag()
        {
            ViewBag.Cobertura = modeloBD.sp_Retorna_Cobertura_De_Poliza(null).ToList();
        }

        void AgregarClientesViewBag()
        {
            ViewBag.Clientes = modeloBD.sp_Retorna_Clientes(null, null, null, null).ToList();
        }

        public ActionResult RetornarCoberturaPorID(int id_Cobertura)
        {
            sp_Retorna_Cobertura_De_PolizaID_Result cobertura = modeloBD.sp_Retorna_Cobertura_De_PolizaID(id_Cobertura).FirstOrDefault();
            return Json(cobertura);
        }
        public ActionResult RetornarNumeroAdicciones(int pId_Cliente)
        {
            List<sp_Retorna_Adiccion_Cliente_Result> adiccionesClientes = modeloBD.sp_Retorna_Adiccion_Cliente(null,null,null,null).ToList();
            var cantidadAdiccionesPorCliente = (from adiccion in modeloBD.Adiccion_Cliente
                                                where adiccion.Id_Cliente == pId_Cliente
                                                select adiccion).Count();
            return Json(cantidadAdiccionesPorCliente);
        }


    }
}