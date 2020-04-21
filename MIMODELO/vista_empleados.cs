namespace MIMODELO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vista_empleados
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_EMPLEADO { get; set; }

        [StringLength(30)]
        public string NOMBRE_EMPLEADO { get; set; }

        [StringLength(50)]
        public string NOMBRE_EMPLEO { get; set; }
    }
}
