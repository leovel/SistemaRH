//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RH.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comuna
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string MunicipioCodigo { get; set; }
    
        public virtual Municipio Municipio { get; set; }
    }
}