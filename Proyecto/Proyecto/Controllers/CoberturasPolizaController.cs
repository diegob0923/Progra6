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
        #region CoberturasPolizaLista
        public ActionResult CoberturasPolizaLista(string CoberturasPoliza)
        {
            List<sp_Retorna_Cobertura_De_Poliza_Result> modeloVista = new List<sp_Retorna_Cobertura_De_Poliza_Result>();

            modeloVista = this.modeloBD.sp_Retorna_Cobertura_De_Poliza(CoberturasPoliza).ToList();


            return View(modeloVista);
        }
        #endregion

        #region Coberturas de poliza insertar y HttpPost
        //Metodo de la vista de insertar Coberturas Poliza
        public ActionResult CoberturasPolizaInserta()
        {

            return View();
        }

        //Metodo httpPost para insertar los datos de coberturas poliza a la 
        //base de datos
        [HttpPost]
        public ActionResult CoberturasPolizaInserta(sp_Retorna_Cobertura_De_Poliza_Result modeloVista)
        {
            string Nombre = modeloVista.Nombre;
            string Descripcion = modeloVista.Descripcion;
            double Porcentaje = modeloVista.Porcentaje;

            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados = this.modeloBD.sp_Insertar_Cobertura_De_Poliza(
                        Nombre,
                        Descripcion,
                       Convert.ToInt32(Porcentaje)
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
                    resultado += "No se pudo insertar";
                }
            }

            ///Para mostrar el mensaje de los exception errores mediante alert
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");


            return View();
        }
        #endregion

        #region Coberturas de poliza modificar y HttpPost
        public ActionResult CoberturasPolizaModifica(int id_Cobertura)
        {
            ///obtener el registro que se desea modificar
            ///utilizando el parámetro del método id_Persona
            sp_Retorna_Cobertura_De_PolizaID_Result modeloVista = new sp_Retorna_Cobertura_De_PolizaID_Result();
            modeloVista = this.modeloBD.sp_Retorna_Cobertura_De_PolizaID(id_Cobertura).FirstOrDefault();
            ///enviar el modelo a la vista
            return View(modeloVista);
        }

        [HttpPost]
        public ActionResult CoberturasPolizaModifica(sp_Retorna_Cobertura_De_PolizaID_Result modeloVista)
        {
            
            string Nombre = modeloVista.Nombre;
            string Descripcion = modeloVista.Descripcion;
            double Porcentaje = modeloVista.Porcentaje;

            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados = this.modeloBD.sp_Modificar_Cobertura_De_Poliza(
                        Convert.ToInt32(modeloVista.Id_Cobertura),
                        Nombre,
                        Descripcion,
                        Convert.ToInt32(Porcentaje)
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
                    resultado = "Registro modificado";
                }
                else
                {
                    resultado += "No se pudo modificar";
                }
            }

            ///Para mostrar el mensaje de los exception errores mediante alert
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");


            return View();
        }

        #endregion

        #region CoberturasPolizaElimina y HttpPost
        public ActionResult CoberturasPolizaElimina(int Id_Cobertura)
        {
            ///obtener el registro que se desea modificar
            ///utilizando el parámetro del método id_Cobertura
            sp_Retorna_Cobertura_De_PolizaID_Result modeloVista = new sp_Retorna_Cobertura_De_PolizaID_Result();
            modeloVista = this.modeloBD.sp_Retorna_Cobertura_De_PolizaID(Id_Cobertura).FirstOrDefault();
            
            return View(modeloVista);
        }

        [HttpPost]
        public ActionResult CoberturasPolizaElimina(sp_Retorna_Cobertura_De_PolizaID_Result modeloVista)
        {
            ///Variable que registra la cantidad de registros afectados
            ///si un procedimiento que ejecuta insert, update o delete 
            ///no afecta registros implica que hubo un error
            int cantRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_Eliminar_Cobertura_De_Poliza(modeloVista.Id_Cobertura);
            }
            catch (Exception error)
            {
                resultado = "Ocurrió un error: " + error.Message;
            }
            finally
            {
                if (cantRegistrosAfectados > 0)
                    resultado = "Registro eliminado";
                else
                    resultado += "No se pudo eliminar";
            }

            
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            return View(modeloVista);

        }
        #endregion
    }
}