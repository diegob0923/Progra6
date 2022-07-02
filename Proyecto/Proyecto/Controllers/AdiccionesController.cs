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

        public ActionResult AdiccionesInsertar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdiccionesInsertar(sp_Retorna_Adicciones_Result modeloVista)
        {
            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados = modeloBD.sp_Insertar_Adicciones(modeloVista.Nombre,modeloVista.Codigo);
            }
            catch (Exception error)
            {
                resultado = "Ocurrió un error: " + error.Message;
            }
            finally
            {
                if (cantRegistrosAfectados > 0)
                {
                    resultado = "Registro insertado";
                }
                else
                {
                    resultado += ".No se pudo insertar ";
                }
            }
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            return View();
        }


    }
}