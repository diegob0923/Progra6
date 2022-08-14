using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class AdiccionesClienteController : Controller
    {
        ProyectoSegurosEntities modeloBD = new ProyectoSegurosEntities();
        public ActionResult AdiccionesClienteLista()
        {
            

            if (Session["TipoUsuario"].ToString() == "Colaborador")

            {
               
                List<sp_Retorna_Adiccion_Cliente_Result> modeloVista = new List<sp_Retorna_Adiccion_Cliente_Result>();
                modeloVista = modeloBD.sp_Retorna_Adiccion_Cliente(null).ToList();
                return View(modeloVista);
                
            }
            else

            {
                
                List<sp_Retorna_Adiccion_Cliente_Result> modeloVista = new List<sp_Retorna_Adiccion_Cliente_Result>();
                modeloVista = modeloBD.sp_Retorna_Adiccion_Cliente(Convert.ToInt32(Session["Cedula"])).ToList();
                return View(modeloVista);
                
            }

        }

        public ActionResult AdiccionesClienteInsertar()
        {
            AgregarAdiccionesViewBag();
            AgregarClientesViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult AdiccionesClienteInsertar(sp_Retorna_Adiccion_Cliente_Result modeloVista)
        {
            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados = modeloBD.sp_Insertar_Adicciones_Clientes(modeloVista.Id_Adiccion,modeloVista.Id_Cliente);
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
                    resultado += "No se pudo insertar";
                }
            }
            
            AgregarAdiccionesViewBag();
            AgregarClientesViewBag();
            TempData["Mensaje"] = resultado;
            return RedirectToAction("AdiccionesClienteLista", "AdiccionesCliente");
        }

        void AgregarAdiccionesViewBag()
        {
            ViewBag.Adicciones = modeloBD.sp_Retorna_Adicciones(null,null).ToList();
        }
        void AgregarClientesViewBag()
        {
            ViewBag.Clientes = modeloBD.sp_Retorna_Clientes(null,null,null,null).ToList(); ;
        }

        public ActionResult AdiccionesClienteModificar(int id)
        {
            sp_Retorna_Adiccion_ClienteID_Result modeloVista = new sp_Retorna_Adiccion_ClienteID_Result();
            modeloVista = modeloBD.sp_Retorna_Adiccion_ClienteID(id).FirstOrDefault();
            AgregarAdiccionesViewBag();
            AgregarClientesViewBag();
            return View(modeloVista);
        }

        [HttpPost]
        public ActionResult AdiccionesClienteModificar(sp_Retorna_Adiccion_ClienteID_Result modeloVista)
        {
            int cantRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantRegistrosAfectados = modeloBD.sp_Modificar_Adicciones_Clientes(modeloVista.Id, modeloVista.Id_Adiccion, modeloVista.Id_Cliente);
            }
            catch (Exception error)
            {
                resultado = "Ocurrió un error: " + error.Message;
            }
            finally
            {
                if (cantRegistrosAfectados > 0)
                {
                    resultado = "Registro modificado";
                }
                else
                {
                    resultado += "No se pudo modificar ";
                }
            }

            
            AgregarAdiccionesViewBag();
            AgregarClientesViewBag();
            TempData["Mensaje"] = resultado;
            return RedirectToAction("AdiccionesClienteLista", "AdiccionesCliente");
        }
        public ActionResult AdiccionesClienteEliminar(int id)
        {
            sp_Retorna_Adiccion_ClienteID_Result modeloVista = new sp_Retorna_Adiccion_ClienteID_Result();
            modeloVista = modeloBD.sp_Retorna_Adiccion_ClienteID(id).FirstOrDefault();
            AgregarAdiccionesViewBag();
            AgregarClientesViewBag();
            return View(modeloVista);
        }

        [HttpPost]
        public ActionResult AdiccionesClienteEliminar(sp_Retorna_Adiccion_ClienteID_Result modeloVista)
        {
            int cantRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantRegistrosAfectados = modeloBD.sp_Eliminar_Adicciones_Cliente(modeloVista.Id);
            }
            catch (Exception error)
            {
                resultado = "Ocurrió un error: " + error.Message;
            }
            finally
            {
                if (cantRegistrosAfectados > 0)
                {
                    resultado = "Registro eliminado";
                }
                else
                {
                    resultado += "No se pudo eliminar ";
                }
            }

            
            AgregarAdiccionesViewBag();
            AgregarClientesViewBag();
            TempData["Mensaje"] = resultado;
            return RedirectToAction("AdiccionesClienteLista", "AdiccionesCliente");
        }

        //Retornar la lista de adicciones cliente para el reporte
        [HttpPost]
        public ActionResult RetornaAdiccionesClienteLista()
        {
            
            if (Session["TipoUsuario"].ToString() == "Colaborador")

            {

                List<sp_Retorna_Adiccion_Cliente_Result> listaAdiccionesCliente =
            this.modeloBD.sp_Retorna_Adiccion_Cliente(null).ToList();

                return Json(new
                {
                    resultado = listaAdiccionesCliente
                });

            }
            else

            {


                List<sp_Retorna_Adiccion_Cliente_Result> listaAdiccionesCliente =
            this.modeloBD.sp_Retorna_Adiccion_Cliente(Convert.ToInt32(Session["Cedula"])).ToList();

                return Json(new
                {
                    resultado = listaAdiccionesCliente
                });

            }



        }
    }
}