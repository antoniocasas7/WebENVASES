//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MIMODELO_envases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Almacene
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Almacene()
        {
            this.Almacen_Articulo = new HashSet<Almacen_Articulo>();
        }

        [Key]
        [Required(ErrorMessage = " El Id es requerido")]
        public int Id { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = " El Nombre es requerido")]
        [DisplayName("Nombre Almacén")]
        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Almacen_Articulo> Almacen_Articulo { get; set; }
    }
}
