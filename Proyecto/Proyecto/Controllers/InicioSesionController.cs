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

                    var usuario = modeloBD.RetornarUsuarioContrasena(Usuario, Contrasena).FirstOrDefault();

                    
                    if (usuario == null )
                    {
                        ViewBag.Error = "Usuario o contraseña incorrecta";
                        return View();
                    }
                    else if(usuario.TipoUsuario == tipoCliente)
                    {
                        Session["Cedula"] = Usuario;
                        Session["TipoUsuario"] = tipoCliente;
                        Session["Usuario"] = usuario;
                        
                        return RedirectToAction("MenuCliente", "MenuCliente");
                        
                    }
                    
                    else if (usuario.TipoUsuario == tipoColaborador)
                    {
                        Session["Cedula"] = Usuario;
                        Session["TipoUsuario"] = tipoColaborador;
                        Session["Usuario"] = usuario;
                        
                        return RedirectToAction("MenuColaborador", "MenuColaborador");
                        
                    }
                    
                }


                return RedirectToAction("","");
                
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