//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sistema_UVM_Control_Presupuestario
{
    using System;
    using System.Collections.Generic;
    
    public partial class PAGO_DIPLOMADO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PAGO_DIPLOMADO()
        {
            this.MES = new HashSet<MES>();
        }
    
        public int ID { get; set; }
        public bool ESTADO { get; set; }
        public string PROGRAMA { get; set; }
        public string MOTIVO { get; set; }
        public long TOTAL { get; set; }
        public int PERSONA_NATURALID { get; set; }
    
        public virtual PERSONA_NATURALes PERSONA_NATURAL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MES> MES { get; set; }
    }
}