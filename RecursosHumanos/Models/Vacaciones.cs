//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecursosHumanos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vacaciones
    {
        public int id { get; set; }
        public string empleado { get; set; }
        public string desde { get; set; }
        public string hasta { get; set; }
        public string año { get; set; }
        public string comentario { get; set; }
    
        public virtual Empleados Empleados { get; set; }
    }
}
