using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail; // Librería utilizada para enviar el correo.
using System.Net; // Librería utilizada para enviar el correo.

namespace Proyecto.Correo
{
    public class EnvioCorreo
    {

        #region Envio de correo al cliente

        // Método utilizado cuando se registra un nuevo cliente al sistema,
        // donde se le enviara un correo electrónico de bienvenida.
        public void EnviarCorreoClienteNuevo(string CorreoCliente, string Nombre, int Usuario, string Contrasena)
        {
            // Cuerpo del correo electrónico
            string body =
            "<body>" +
                $"<h4><b>Estimado cliente:</b>{Nombre}</h4>" +
                "<span>Gracias por confiar en Seguros el Equipo del Siglo XXI. Para nosotros es un placer servirle. A continuación, </span><br/>" +
                "<span>sus credenciales para ingresar a la aplicación.</ span ><br/> " +
                $"<span>Sitio web: http://localhost:61050/InicioSesion/InicioSesion </span><br/>" +
                $"<span>Usuario:{Usuario} Contraseña:{Contrasena}.</span><br/>" +
                 "<br/><br/><br/><br/><span><b>Mensaje autogenerado, por favor no responder.</b></span>" +
            "</body>";

            // Servidor del correo electrónico que se utiliza para enviar el correo.
            SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com", 587);
            // Credenciales del correo electrónico del Centro médico, utilizado para enviar correos
            smtp.Credentials = new NetworkCredential("pruebasprueba95@hotmail.com", "Pruebaspruebas95");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;

            MailMessage mail = new MailMessage();
            // Correo electrónico que se enviara al cliente con el motivo
            mail.From = new MailAddress("pruebasprueba95@hotmail.com", "Su cuenta en Seguros el Equipo del Siglo XXI");

            // Cuerpo del correo anteriormente creado
            mail.To.Add(new MailAddress(CorreoCliente));
            mail.Subject = "Su cuenta en Seguros El Equipo del Siglo XXI.";
            mail.IsBodyHtml = true;
            mail.Body = body;
            // Envía el correo electrónico
            smtp.Send(mail);
        }

        #endregion
    }
}