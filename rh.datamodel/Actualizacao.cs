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
    
    public partial class Actualizacao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Actualizacao()
        {
            this.Oservacoes = "";
            this.DadosIniciais = new DadosDeActualizacao();
            this.DadosFinais = new DadosDeActualizacao();
        }
    
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public string Oservacoes { get; set; }
    
        public DadosDeActualizacao DadosIniciais { get; set; }
        public DadosDeActualizacao DadosFinais { get; set; }
    
        public virtual Funcionario Funcionario { get; set; }
    }
}
