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
    
    public partial class Contrato
    {
        public TipoDeContrato Tipo { get; set; }
        public ClaseDeServico ClasseDeServico { get; set; }
        public System.DateTime DataInicial { get; set; }
        public Nullable<System.DateTime> DataFinal { get; set; }
        public string Numero { get; set; }
    }
}
