//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cliente
    {
        public Cliente()
        {
            this.Adiccion_Cliente = new HashSet<Adiccion_Cliente>();
            this.Registro_Polizas = new HashSet<Registro_Polizas>();
        }
    
        public int Id_Cliente { get; set; }
        public int Cedula { get; set; }
        public string Genero { get; set; }
        public System.DateTime Fecha_Nacimiento { get; set; }
        public string Nombre { get; set; }
        public string Primer_Apellido { get; set; }
        public string Segundo_Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Correo { get; set; }
        public int Id_Provincia { get; set; }
        public int Id_Canton { get; set; }
        public int Id_Distrito { get; set; }
    
        public virtual ICollection<Adiccion_Cliente> Adiccion_Cliente { get; set; }
        public virtual ICollection<Registro_Polizas> Registro_Polizas { get; set; }
    }
}
