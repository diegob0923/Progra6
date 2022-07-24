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

        ProyectoSegurosEntities modeloBD = new ProyectoSegurosEntities();

        public ActionResult InicioSesion()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult InicioSesion(int Usuario, string Contrasena)
        {
            //Arreglar 

            //RetornarUsuarioContrasena_Result
            //    Resultado = this.modeloBD.RetornarUsuarioContrasena(Usuario, Contrasena).FirstOrDefault();
            //string Mensaje = "";

            ///// Verificar si el objeto es nulo, si lo es,
            ///// entonces el usuario y contraseña son incorrectos
            //if (Resultado == null)
            //{
            //   Mensaje = "Usuario o contraseña incorrectos";
            //    Response.Write("<script language=javascript>alert('" + Mensaje + "');</script>");

            //}
            //else
            //{

            //    if (DatosDoctor == null)
            //    {
            //        this.Session.Add("ultimoIngreso", "Esta es su primera vez en el sistema");
            //    }
            //    else
            //    {
            //        this.Session.Add("ultimoIngreso", DatosDoctor.Fecha_Ultimo_Ingreso);
            //        this.ModeloBD.InsertarRegistroIngreso(Resultado.correoElectronico);
            //    }
            //    // Variables de sesión
            //    this.ModeloBD.InsertarRegistroIngreso(Resultado.correoElectronico);
            //    this.Session.Add("nombreUsuario", Resultado.nombreCompleto);
            //    this.Session.Add("idUsuario", Resultado.id_Usuario);
            //    this.Session.Add("usuarioLogeado", true);
            //    this.Session.Add("tipoUsuario", Resultado.tipoUsuario);
            //    this.Response.Redirect("~/Formularios/FrmPaginaPrincipal.aspx");
            //}
            
            try
            {
                using (Models.ProyectoSegurosEntities modeloBD = new ProyectoSegurosEntities())
                {
                    //string tipo = "";
                    string tipoCliente = "Cliente";
                    string tipoColaborador = "Colaborador";
                    var usuario1 = (from login in modeloBD.Usuarios_Sistema
                                   where login.Usuario == Usuario && login.Contrasena == Contrasena.Trim() && login.TipoUsuario == tipoCliente
                                   select login).FirstOrDefault();
                    var usuario2 = (from login in modeloBD.Usuarios_Sistema
                                    where login.Usuario == Usuario && login.Contrasena == Contrasena.Trim() && login.TipoUsuario == tipoColaborador
                                    select login).FirstOrDefault();
                    var TipoCliente = (from T in modeloBD.Usuarios_Sistema where T.TipoUsuario == tipoCliente select T).FirstOrDefault();
                    var TipoColaborador = (from T in modeloBD.Usuarios_Sistema where T.TipoUsuario == tipoColaborador select T).FirstOrDefault();

                    if (usuario1 == null && usuario2 == null)
                    {
                        ViewBag.Error = "Usuario o contraseña incorrecta";
                        return View();
                    }
                    else if(usuario1 == TipoCliente)
                    {


                        Session["Usuario"] = usuario1;
                        return RedirectToAction("ClientesLista", "Clientes");
                    }
                    
                    else if (usuario2 == TipoColaborador)
                    {
                        
                        Session["Usuario"] = usuario2;
                        return RedirectToAction("CoberturasPolizaLista", "CoberturasPoliza");
                    }
                    //Session["Usuario"] = usuario;
                }


                return RedirectToAction("","");
                //RedirectToAction("ClientesLista","Clientes");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }

        }
    }
}