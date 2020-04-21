namespace MIMODELO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Almacene
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string Nombre { get; set; }
    }
}
