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
        private Models.Usuarios_Sistema usuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                usuario = (Models.Usuarios_Sistema)HttpContext.Current.Session["Usuario"];
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

    }
}