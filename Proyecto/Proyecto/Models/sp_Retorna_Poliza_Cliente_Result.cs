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
    
    public partial class sp_Retorna_Poliza_Cliente_Result
    {
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Primer_Apellido { get; set; }
        public string Segundo_Apellido { get; set; }
        public int Id_Poliza { get; set; }
        public string Cobertura { get; set; }
        public decimal Monto_Asegurado { get; set; }
        public double Porcentaje_Cobertura { get; set; }
        public int Numero_Adicciones { get; set; }
        public decimal Monto_Adicciones { get; set; }
        public decimal Prima_Antes_Impuestos { get; set; }
        public decimal Impuestos { get; set; }
        public decimal Prima_Final { get; set; }
        public System.DateTime Fecha_Vencimiento { get; set; }
    }
}
