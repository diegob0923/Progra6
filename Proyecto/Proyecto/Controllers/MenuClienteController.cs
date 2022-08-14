using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class MenuClienteController : Controller
    {
        #region Menu de cliente
        // GET: MenuCliente
        public ActionResult MenuCliente()
        {
            return View();
        }
        #endregion
    }
}