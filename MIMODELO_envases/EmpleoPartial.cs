using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMODELO_envases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;

    public partial class Empleo : IEmpleo
    {
        #region MIO
        //HECHO POR MI

        public async Task<bool> Create(MIMODELO_envases.Empleo empleo)
        {
            try
            {
                using (var context = new ENVASESEntities())
                {

                    context.Empleos.Add(empleo);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.Message);

            }
        }

        public async Task<List<MIMODELO_envases.Empleo>> List()
        {
            try
            {
                using (var context = new ENVASESEntities())
                {
                    return await context.Empleos.ToListAsync();
                }
            }
            catch (Exception e)
            {
                return null;
                throw new Exception(e.Message);
            }
        }

        public async Task<MIMODELO_envases.Empleo> EditByEmpleo(MIMODELO_envases.Empleo empleo)
        {
            try
            {
                using (var context = new ENVASESEntities())
                {
                    context.Entry(empleo).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    return empleo;
                }
            }
            catch (Exception e)
            {
                return null;
                throw new Exception(e.Message);
            }
        }

        public async Task<MIMODELO_envases.Empleo> EditById(int? id)
        {
            try
            {
                using (var context = new ENVASESEntities())
                {
                    var empleo = this.Details(id);
                    if (empleo != null)
                    {
                        context.Entry(empleo).State = EntityState.Modified;
                        await context.SaveChangesAsync();
                        return empleo.Result;
                    }
                    else
                        return null;
                }
            }
            catch (Exception e)
            {
                return null;
                throw new Exception(e.Message);
            }
        }

        public async Task<MIMODELO_envases.Empleo> Details(int? id)
        {
            try
            {
                using (var context = new ENVASESEntities())
                {
                    // return await context.Empleos.FindAsync(id);
                    return await context.Empleos.Include("Empleados").FirstOrDefaultAsync(c => c.Id == id);
                }

            }
            catch (Exception e)
            {
                return null;
                throw new Exception(e.Message);
            }
        }

        public async Task<Empleo> DeleteByEmpleo(Empleo empleo)
        {
            try
            {
                using (var context = new ENVASESEntities())
                {
                    context.Empleos.Attach(empleo);
                    context.Empleos.Remove(empleo);
                    await context.SaveChangesAsync();
                    return empleo;
                }
            }
            catch (Exception e)
            {
                return null;
                throw new Exception(e.Message);
            }          
        }



        //public PersonaAnimal NuevoEditar(string dni)
        //{
        //    var varpersonaanimal = new PersonaAnimal();
        //    try
        //    {
        //        if (dni.ToString() != null)
        //        {
        //            //EL ANIMAL ENTRE COMILLAS DOBLES ES LA PROPIEDAD DEFINIDA ARRIBA
        //            using (var context = new AdventureContext())
        //            {
        //                varpersonaanimal = context.PersonaAnimal
        //                                    .Include("Animal")
        //                                    .Where(x => x.dni.Equals(dni))
        //                                    .Single();
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }

        //    return (varpersonaanimal);
        //}

        //public void Guardar(string varestado)
        //{
        //    try
        //    {
        //        //EL ANIMAL ENTRE COMILLAS DOBLES ES LA PROPIEDAD DEFINIDA ARRIBA
        //        using (var context = new AdventureContext())
        //        {
        //            //NUEVO
        //            //ESTO del dni cambiarlo
        //            if (varestado == "Nuevo Registro")
        //            {
        //                context.Entry(this).State = System.Data.Entity.EntityState.Added;
        //            }
        //            //ACTUALIZAR              
        //            else
        //            {
        //                /*     context.Database.ExecuteSqlCommand(
        //                   "DELETE FROM Animal WHERE dnipropietario = "+ this.dni,
        //                   new SqlParameter("dnipropietario", this.dni)
        //               );
        //               */
        //                context.Entry(this).State = System.Data.Entity.EntityState.Modified;
        //            }

        //            foreach (var c in this.Animal)
        //                context.Entry(c).State = System.Data.Entity.EntityState.Unchanged;

        //            context.SaveChanges();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}



        //public void Eliminar(string dni)
        //{
        //    try
        //    {
        //        using (var context = new AdventureContext())
        //        {
        //            context.Entry(new PersonaAnimal { dni = dni }).State = System.Data.Entity.EntityState.Deleted;
        //            context.SaveChanges();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public PersonaAnimal Visualizar(string dni)
        //{
        //    var varpersonaanimal = new PersonaAnimal();
        //    try
        //    {
        //        //EL ANIMAL ENTRE COMILLAS DOBLES ES LA PROPIEDAD DEFINIDA ARRIBA
        //        using (var context = new AdventureContext())
        //        {
        //            varpersonaanimal = context.PersonaAnimal
        //                                .Include("Animal")
        //                                .Where(x => x.dni.Equals(dni))
        //                                .Single();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //    return (varpersonaanimal);
        //}



        //HASTA AQUI
        #endregion
    }
}
