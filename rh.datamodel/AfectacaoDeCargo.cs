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
    
    public partial class AfectacaoDeCargo : AfectacaoSalarial
    {
        public int CargoId { get; set; }
    
        public virtual Cargo Cargo { get; set; }
    }
}