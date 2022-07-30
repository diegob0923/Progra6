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
        [HttpPost]
        public ActionResult RegistroPolizasInsertar(Retorna_Registro_Polizas_Result modeloVista)
        {
            int cantRegistrosAfectados = 0;
            string resultado = "";

            try
            {

                cantRegistrosAfectados = modeloBD.sp_Insertar_Registro_Polizas(
                   modeloVista.Id_Cobertura,
                   modeloVista.Id_Cliente,
                   modeloVista.Monto_Asegurado,
                   modeloVista.Porcentaje_Cobertura,
                   modeloVista.Numero_Adicciones,
                   modeloVista.Monto_Adicciones,
                   modeloVista.Prima_Antes_Impuestos,
                   modeloVista.Impuestos,
                   modeloVista.Prima_Final,
                   modeloVista.Fecha_Vencimiento
                    );
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
            
            AgregarCoberturaViewBag();
            AgregarClientesViewBag();
            return View(modeloVista);
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
        
        public ActionResult RetornarNumeroAdicciones(int id_Cliente)
        {
            int cantidadClientes = (int)modeloBD.Retornar_Cantidad_Adicciones_Por_Cliente(id_Cliente).FirstOrDefault();
            return Json(cantidadClientes);
        }


    }
}