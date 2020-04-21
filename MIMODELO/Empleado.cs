namespace MIMODELO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Empleados")]
    public partial class Empleado
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Apellidos { get; set; }

        public int? Id_Empleo { get; set; }

        public virtual Empleo Empleo { get; set; }
    }
}
