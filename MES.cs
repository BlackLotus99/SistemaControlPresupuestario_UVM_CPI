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
    
    public partial class MES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MES()
        {
            this.SALIDA_TERRENO = new HashSet<SALIDA_TERRENO>();
        }
    
        public int ID { get; set; }
        public string NOMBRE_MES { get; set; }
        public int CONSOLIDADOID { get; set; }
    
        public virtual CONSOLIDADO CONSOLIDADO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SALIDA_TERRENO> SALIDA_TERRENO { get; set; }
        public virtual PAGO_DIPLOMADO PAGO_DIPLOMADO { get; set; }
    }
}