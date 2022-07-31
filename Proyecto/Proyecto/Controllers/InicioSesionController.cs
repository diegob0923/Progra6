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

        #region diferenciar usuarios 
        [HttpPost]
        public ActionResult InicioSesion(int Usuario, string Contrasena)
        {
            
            try
            {
                using (Models.ProyectoSegurosEntities modeloBD = new ProyectoSegurosEntities())
                {
                    
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
                        return RedirectToAction("MenuCliente", "MenuCliente");
                    }
                    
                    else if (usuario2 == TipoColaborador)
                    {
                        
                        Session["Usuario"] = usuario2;
                        return RedirectToAction("MenuColaborador", "MenuColaborador");
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
        #endregion
    }
}