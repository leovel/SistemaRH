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
    
    [Flags]
    public enum NivelDeCredencial : int
    {
        ZERO = 0,
        BASICO = 1,
        SUPERIOR = 31,
        GESTOR = 127,
        ADMINISTRADOR = 511,
        ADMINISTRADOR_SUPERIOR = 1023,
        DEVELOPER = 4095
    }
}
