namespace MIMODELO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Articulos")]
    public partial class Articulo
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }
    }
}
