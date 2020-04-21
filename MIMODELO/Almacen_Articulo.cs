namespace MIMODELO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Almacen_Articulo
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Almacen { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Articulo { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha_Entrada { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha_Salida { get; set; }

        public decimal? Cantidad { get; set; }
    }
}
