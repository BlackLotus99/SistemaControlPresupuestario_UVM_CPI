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
    
    public partial class RENDICION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RENDICION()
        {
            this.DETALLE_RENDICION = new HashSet<DETALLE_RENDICION>();
        }
    
        public int ID { get; set; }
        public bool ESTADO { get; set; }
        public string DESCRIPCION { get; set; }
        public string ESTADO_ANTICIPO { get; set; }
        public System.DateTime FECHA { get; set; }
        public int ID_RENDICION { get; set; }
        public string DETALLE_VARIOS { get; set; }
        public int PERSONA_NATURALID { get; set; }
        public int PERSONA_JURIDICAID { get; set; }
    
        public virtual PERSONA_JURIDICAs PERSONA_JURIDICA { get; set; }
        public virtual PERSONA_NATURALes PERSONA_NATURAL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_RENDICION> DETALLE_RENDICION { get; set; }
    }
}
