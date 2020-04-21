namespace MIMODELO
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MiModelo : DbContext
    {
        public MiModelo()
            : base("name=MiModeloEnvases")
        {
        }

        public virtual DbSet<Almacen_Articulo> Almacen_Articulo { get; set; }
        public virtual DbSet<Almacene> Almacenes { get; set; }
        public virtual DbSet<Articulo> Articulos { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Empleo> Empleos { get; set; }
        public virtual DbSet<vista_empleados> vista_empleados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Almacen_Articulo>()
                .Property(e => e.Cantidad)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Empleo>()
                .HasMany(e => e.Empleados)
                .WithOptional(e => e.Empleo)
                .HasForeignKey(e => e.Id_Empleo)
                .WillCascadeOnDelete();
        }
    }
}
