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
    
    public partial class Adicciones
    {
        public Adicciones()
        {
            this.Adiccion_Cliente = new HashSet<Adiccion_Cliente>();
        }
    
        public int Id_Adiccion { get; set; }
        public string Nombre { get; set; }
        public int Codigo { get; set; }
    
        public virtual ICollection<Adiccion_Cliente> Adiccion_Cliente { get; set; }
    }
}
