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
    
    public partial class SALIDA_TERRENO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SALIDA_TERRENO()
        {
            this.MES = new HashSet<MES>();
        }
    
        public int ID { get; set; }
        public bool ESTADO { get; set; }
        public string TIPO_SALIDA { get; set; }
        public string UBICACION { get; set; }
        public short CANTIDAD_ALUMNOS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MES> MES { get; set; }
    }
}
