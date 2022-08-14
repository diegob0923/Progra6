using System.Web;
using System.Web.Mvc;

namespace Proyecto
{
    public class FilterConfig
    {
        //Representa una clase que contiene todos los filtros globales.
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //atributo que se usa para controlar una excepción que genera un método de acción
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Filtros.VerificarSesion());
        }
    }
}

