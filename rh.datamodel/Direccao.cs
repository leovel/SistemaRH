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
    
    public partial class Direccao : AreaDeTrabalho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Direccao()
        {
            this.Departamentos = new HashSet<Departamento>();
            this.Direccoes = new HashSet<Direccao>();
        }
    
        public Nullable<int> DireccaoSuperiorId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Departamento> Departamentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Direccao> Direccoes { get; set; }
        public virtual Direccao DireccaoSuperior { get; set; }
    }
}
