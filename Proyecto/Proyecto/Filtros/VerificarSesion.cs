using Proyecto.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Filtros
{
    public class VerificarSesion : ActionFilterAttribute
    {
        #region Verificar el inicio de sesión 
        //Verifica la sesión del usuario para permitir ingresar
        //Proporciona el contexto para el método ActionExecuting de la clase ActionFilterAttribute.
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                //se ejecuta toda la lógica de autorización 
                base.OnActionExecuting(filterContext);
                
                var usuario = HttpContext.Current.Session["Usuario"];
                if (usuario == null)
                {
                    if (filterContext.Controller is InicioSesionController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/InicioSesion/InicioSesion");
                    }
                }
            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("/InicioSesion/InicioSesion");
            }
        }
        #endregion
    }
}