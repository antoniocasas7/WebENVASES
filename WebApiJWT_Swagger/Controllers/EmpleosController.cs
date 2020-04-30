using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MIMODELO_envases;

namespace WebApiJWT_Swagger.Controllers
{
    /// <summary>
    /// Controlador Login para autentificacion de usuarios
    /// </summary>
    [Authorize]
    //[AllowAnonymous]
    [RoutePrefix("api/Empleos")]
    public class EmpleosController : ApiController
    {
        private ENVASESEntities db = new ENVASESEntities();


        /// <summary>
        /// Devuelve todos los empleos
        /// </summary>     
        /// <returns>Lista de Empleos</returns> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>              
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        // GET: api/Empleos
        [Route("GetEmpleos")]
        [ResponseType(typeof(IQueryable<Empleo>))]
        [HttpGet]
        public IQueryable<Empleo> GetEmpleos()
        {
            return db.Empleos;
        }

        /// <summary>
        /// Devuelve un empleo segun el Id pasado como parametro 
        /// </summary>
        /// <param name="id"> Id del empleo a busacar</param> <seealso cref="int"></seealso>
        /// <returns>Empleo bus</returns> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>              
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// 
        // GET: api/Empleos/5
        [HttpGet]
       // [Route("GetEmpleo")]  // En este caso el id se pasa como parametro en la llamada postman: http://localhost:44387/api/Empleos/GetEmpleo?id=6
        [Route("GetEmpleo/{id:int}")]  // El Route de arriba funciona tambien , hago este para tener las 2 formas
        [ResponseType(typeof(Empleo))]   //     lo que cambia es al llamar en postman esta el id va en la URI: http://localhost:44387/api/Empleos/GetEmpleo/6
        public async Task<IHttpActionResult> GetEmpleo([FromUri] int id)
        {
            Empleo empleo = await db.Empleos.FindAsync(id);
            if (empleo == null)
            {
                return NotFound();
            }

            return Ok(empleo);
        }

        /// <summary>
        /// Edita un empleo segun el Id pasado como parametro y el empleo
        /// </summary>       
        /// <param name="id"> Id del empleo a editar</param> <seealso cref="int"></seealso>
        /// <param name="empleo"> Datos actualizados del empleo a editar</param>  <seealso cref="Empleo"></seealso>
        /// <returns></returns> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>              
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        // POST: api/Empleos?id=6   http://localhost:44387/api/Empleos/GetEmpleo?id=6
        //  [HttpPost]
        [Route("EditEmpleo")]
        [ResponseType(typeof(IHttpActionResult))]
        public async Task<IHttpActionResult> EditEmpleo([FromUri] int id, [FromBody] Empleo empleo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empleo.Id)
            {
                return BadRequest();
            }

            db.Entry(empleo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Crea un Empleo
        /// </summary>       
        /// <param name="empleo"> Datos del empleo a crear</param>  <seealso cref="Empleo"></seealso>
        /// <returns></returns> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>              
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        // POST: api/Empleos
        [HttpPost]
        [Route("AddEmpleo")]
     
        [ResponseType(typeof(Empleo))]
        public async Task<IHttpActionResult> AddEmpleo([FromBody] Empleo empleo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Empleos.Add(empleo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = empleo.Id }, empleo);
        }

        /// <summary>
        /// Elimina Empleo
        /// </summary>       
        /// <param name="id"> Id del empleo a eliminar</param>  
        /// <returns></returns> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>              
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        // DELETE: api/Empleos/5
        [HttpDelete]
        [Route("DeleteEmpleo")]
        [ResponseType(typeof(Empleo))]
        public async Task<IHttpActionResult> DeleteEmpleo([FromUri] int id)
        {
            Empleo empleo = await db.Empleos.FindAsync(id);
            if (empleo == null)
            {
                return NotFound();
            }

            db.Empleos.Remove(empleo);
            await db.SaveChangesAsync();

            return Ok(empleo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpleoExists(int id)
        {
            return db.Empleos.Count(e => e.Id == id) > 0;
        }
    }
}