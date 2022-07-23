using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.Filtros;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class InicioSesionController : Controller
    {

        // GET: InicioSesion
        

        public ActionResult InicioSesion()
        {
            return View();
        }

        void RealizarAutenticacion()
        {
            RetornarUsuarioContrasena_Result
                Resultado = this.ModeloBD.RetornarUsuarioContrasena(this.txtCorreo.Text, this.txtContrasena.Text).FirstOrDefault();


            /// Verificar si el objeto es nulo, si lo es,
            /// entonces el usuario y contraseña son incorrectos
            if (Resultado == null)
            {
                lblMensaje.Text = "Correo eléctronico ó contraseña incorrectos";
                this.txtCorreo.Text = "";
                this.txtCorreo.Focus();
                this.Session.Add("nombreUsuario", null);
                this.Session.Add("ultimoIngreso", null);
                this.Session.Add("idUsuario", null);
                this.Session.Add("usuarioLogeado", false);
                this.Session.Add("tipoUsuario", null);
            }
            else
            {
                // Se obtiene los datos del doctor que está ingresando al sistema, para conocer cuál fue su ultima
                // vez que utilizo el sistema.
                RetornaRegistroIngreso_Result DatosDoctor = this.ModeloBD.RetornaRegistroIngreso(txtCorreo.Text).FirstOrDefault();

                // Si no se encontró registros del doctor, quiere decir que es la primera vez
                // que utiliza el sistema.
                // al contrario, si se encontraron registros, se obtiene la fecha y hora
                // de la ultima vez que utilizo el sistema.
                if (DatosDoctor == null)
                {
                    this.Session.Add("ultimoIngreso", "Esta es su primera vez en el sistema");
                }
                else
                {
                    this.Session.Add("ultimoIngreso", DatosDoctor.Fecha_Ultimo_Ingreso);
                    this.ModeloBD.InsertarRegistroIngreso(Resultado.correoElectronico);
                }
                // Variables de sesión
                this.ModeloBD.InsertarRegistroIngreso(Resultado.correoElectronico);
                this.Session.Add("nombreUsuario", Resultado.nombreCompleto);
                this.Session.Add("idUsuario", Resultado.id_Usuario);
                this.Session.Add("usuarioLogeado", true);
                this.Session.Add("tipoUsuario", Resultado.tipoUsuario);
                this.Response.Redirect("~/Formularios/FrmPaginaPrincipal.aspx");
            }
        }


        [HttpPost]
        public ActionResult InicioSesion(int Usuario, string Contrasena)
        {
            try
            {
                using (Models.ProyectoSegurosEntities modeloBD = new ProyectoSegurosEntities())
                {
                    var usuario = (from login in modeloBD.Usuarios_Sistema
                                   where login.Usuario == Usuario && login.Contrasena == Contrasena.Trim()
                                   select login).FirstOrDefault();

                    if (usuario == null)
                    {
                        ViewBag.Error = "Usuario o contraseña incorrecta";
                        return View();
                    }
                    Session["Usuario"] = usuario;
                }


                return View();
                    //RedirectToAction("ClientesLista","Clientes");
            }
            catch(Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }

        }
    }
}