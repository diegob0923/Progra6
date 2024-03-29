using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;
using Proyecto.Correo;
using Proyecto.Filtros;

namespace Proyecto.Controllers
{
    public class ClientesController : Controller
    {

        ProyectoSegurosEntities modeloBD = new ProyectoSegurosEntities();

        // GET: Clientes
        #region Clientes Lista

        public ActionResult ClientesLista()
        {          
            if (Session["TipoUsuario"].ToString() == "Colaborador")

            {
                ///int cedula, string nombre, string primer_apellido, string segundo_apellido
                List<sp_Retorna_Clientes_Result> modeloVista = new List<sp_Retorna_Clientes_Result>();
                modeloVista = this.modeloBD.sp_Retorna_Clientes(null, null, null, null).ToList();
                return View(modeloVista);
            }
            else

            {
                ///int cedula, string nombre, string primer_apellido, string segundo_apellido
                List<sp_Retorna_Clientes_Result> modeloVista = new List<sp_Retorna_Clientes_Result>();
                modeloVista = this.modeloBD.sp_Retorna_Clientes(Convert.ToInt32(Session["Cedula"]), null, null, null).ToList();
                return View(modeloVista);
            }       
        }
        #endregion

        #region Clientes insertar, metodos retornar Json( provincia, canton, distrito) y HttpPost
        //Método de la vista de insertar clientes
        public ActionResult ClientesInserta()
        {
            return View();
        }

        //Metodo para retornar las provincias
        public ActionResult RetornarProvincias()
        {
            List<RetornaProvincias_Result> provincias = new List<RetornaProvincias_Result>();
            provincias = this.modeloBD.RetornaProvincias(null).ToList();
            ViewBag.Provincias = provincias;
            return Json(provincias);
        }

        //Método para retornar los cantones tomando en cuenta el id de provincia
        public ActionResult RetornarCantones(int Id_Provincia)
        {
            List<RetornaCantones_Result> cantones = new List<RetornaCantones_Result>();
            cantones = this.modeloBD.RetornaCantones(null, Id_Provincia).ToList();
            ViewBag.Cantones = cantones;
            return Json(cantones);
        }
        //Método para retornar los distritos tomando en cuenta el id de cantón
        public ActionResult RetornarDistritos(int Id_Canton)
        {
            List<RetornaDistritos_Result> distritos = new List<RetornaDistritos_Result>();
            distritos = this.modeloBD.RetornaDistritos(null, Id_Canton).ToList();
            ViewBag.Distritos = distritos;
            return Json(distritos);
        }

        void AgregarProvinciaCantonDistritoViewBag()
        {
            List<RetornaProvincias_Result> provincias = new List<RetornaProvincias_Result>();
            provincias = this.modeloBD.RetornaProvincias(null).ToList();
            ViewBag.Provincias = provincias;
            List<RetornaCantones_Result> cantones = new List<RetornaCantones_Result>();
            cantones = this.modeloBD.RetornaCantones(null, null).ToList();
            ViewBag.Cantones = cantones;
            List<RetornaDistritos_Result> distritos = new List<RetornaDistritos_Result>();
            distritos = this.modeloBD.RetornaDistritos(null, null).ToList();
            ViewBag.Distritos = distritos;
        }

        //Método httpPost para insertar los datos de Clientes a la 
        //base de datos
        [HttpPost]
        public ActionResult ClientesInserta(sp_Retorna_Clientes_Result modeloVista)
        {
            //Inicio Contraseña aleatoria
            Random rdn = new Random();
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890%$#@";
            int longitud = caracteres.Length;
            char letra;
            int longitudContrasenia = 5;
            string contraseniaAleatoria = string.Empty;
            for (int i = 0; i < longitudContrasenia; i++)
            {
                letra = caracteres[rdn.Next(longitud)];
                contraseniaAleatoria += letra.ToString();
            }
            //Final Contraseña aleatoria

            string TipoUsuario = "Cliente";

            int Cedula = modeloVista.Cedula;
            string Genero = modeloVista.Genero;
            DateTime Fecha_Nacimiento = modeloVista.Fecha_Nacimiento;
            string Nombre = modeloVista.Nombre;
            string Primer_Apellido = modeloVista.Primer_Apellido;
            string Segundo_Apellido = modeloVista.Segundo_Apellido;
            string Direccion = modeloVista.Direccion;
            string Telefono1 = modeloVista.Telefono1;
            string Telefono2 = modeloVista.Telefono2;
            string Correo = modeloVista.Correo;
            int Id_Provincia = modeloVista.id_Provincia;
            int Id_Canton = modeloVista.id_Canton;
            int Id_Distrito = modeloVista.id_Distrito;

            int cantRegistrosAfectados = 0;

            string resultado = "";
            try
            {
                cantRegistrosAfectados = this.modeloBD.sp_Insertar_Clientes(
                       Cedula,
                       Genero,
                       Fecha_Nacimiento,
                       Nombre,
                       Primer_Apellido,
                       Segundo_Apellido,
                       Direccion,
                       Telefono1,
                       Telefono2,
                       Correo,
                       Id_Provincia,
                       Id_Canton,
                       Id_Distrito
                       );
                this.modeloBD.sp_Insertar_Usuarios(
                    Cedula,
                    contraseniaAleatoria,
                    TipoUsuario
                        );

            }
            catch (Exception error)
            {
                resultado = "Ocurrió un error: " + error.Message;
            }

            if (cantRegistrosAfectados > 0)
            {
                resultado = "Registro insertado";

                EnviarCorreos(Correo, Nombre, Primer_Apellido, Segundo_Apellido, Cedula, contraseniaAleatoria);
            }
            else
            {
                resultado += "No se pudo insertar";
            }
            
            TempData["Mensaje"] = resultado;
            return RedirectToAction("ClientesLista", "Clientes");
        }
        #endregion

        #region EnviarCorreos

        void EnviarCorreos(string Correo, string Nombre, string Primer_Apellido, string Segundo_Apellido, int Cedula, string contrasenia)
        {

            //Se llama a la clase que contiene los demás procedimientos para el envió del correo
            EnvioCorreo envio = new EnvioCorreo();
            string CorreoCliente = Correo;
            int Usuario = Cedula;
            string Contrasena = contrasenia;
            string NombreCliente = Primer_Apellido + " " + Segundo_Apellido + " " + Nombre;

            envio.EnviarCorreoClienteNuevo(CorreoCliente, NombreCliente, Usuario, Contrasena);
        }

        #endregion

        #region Clientes modificar
        public ActionResult ClientesModifica(int id_Cliente)
        {
            ///obtener el registro que se desea modificar
            ///utilizando el parámetro del método id_Cliente
            sp_Retorna_ClienteID_Result modeloVista = new sp_Retorna_ClienteID_Result();
            modeloVista = this.modeloBD.sp_Retorna_ClienteID(id_Cliente).FirstOrDefault();
            //agregar datos al provincia, canton, distrito ViewBag, después se usarán para cargar los dropdown de la vista
            AgregarProvinciaCantonDistritoViewBag();
            ///enviar el modelo a la vista
            return View(modeloVista);
        }

        [HttpPost]
        public ActionResult ClientesModifica(sp_Retorna_ClienteID_Result modeloVista)
        {

            int Cedula = modeloVista.Cedula;
            string Genero = modeloVista.Genero;
            DateTime Fecha_Nacimiento = modeloVista.Fecha_Nacimiento;
            string Nombre = modeloVista.Nombre;
            string Primer_Apellido = modeloVista.Primer_Apellido;
            string Segundo_Apellido = modeloVista.Segundo_Apellido;
            string Direccion = modeloVista.Direccion;
            string Telefono1 = modeloVista.Telefono1;
            string Telefono2 = modeloVista.Telefono2;
            string Correo = modeloVista.Correo;
            int Id_Provincia = modeloVista.Id_Provincia;
            int Id_Canton = modeloVista.Id_Canton;
            int Id_Distrito = modeloVista.Id_Distrito;

            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados = this.modeloBD.sp_Modificar_Clientes(
                        modeloVista.Id_Cliente,
                        Cedula,
                        Genero,
                        Fecha_Nacimiento,
                        Nombre,
                        Primer_Apellido,
                        Segundo_Apellido,
                        Direccion,
                        Telefono1,
                        Telefono2,
                        Correo,
                        Id_Provincia,
                        Id_Canton,
                        Id_Distrito
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

            AgregarProvinciaCantonDistritoViewBag();
            TempData["Mensaje"] = resultado;
            return RedirectToAction("ClientesLista", "Clientes");
        }

        #endregion

        #region Clientes Eliminar
        public ActionResult ClientesElimina(int Id_Cliente)
        {
            ///obtener el registro que se desea modificar
            ///utilizando el parámetro del método id_Cobertura
            sp_Retorna_ClienteID_Result modeloVista = new sp_Retorna_ClienteID_Result();
            modeloVista = this.modeloBD.sp_Retorna_ClienteID(Id_Cliente).FirstOrDefault();

            return View(modeloVista);
        }

        [HttpPost]
        public ActionResult ClientesElimina(sp_Retorna_ClienteID_Result modeloVista)
        {
            ///Variable que registra la cantidad de registros afectados
            ///si un procedimiento que ejecuta insert, update o delete 
            ///no afecta registros implica que hubo un error
            int cantRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_Eliminar_Clientes(modeloVista.Id_Cliente);
            }
            catch (Exception error)
            {
                resultado = "Ocurrió un error: " + error.Message;
            }

            if (cantRegistrosAfectados > 0)
            {
                resultado = "Registro eliminado";

            }
            else
            {
                resultado += "No se pudo eliminar";
            }

            TempData["Mensaje"] = resultado;
            return RedirectToAction("ClientesLista", "Clientes");
        }
        #endregion
    }
}