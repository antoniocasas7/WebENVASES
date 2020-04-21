using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MIMODELO_envases;

namespace WEB_MVC_FRONT.Controllers
{
    /// <summary>
    /// ESTE CONTROLADOR ESTA HECHO TIRANDO DE LAS FUNCIONES QUE ESTAN EN LA CLASE PARCIAL
    /// EN VEZ DE DECLARAR LAS OPERACIONES DE LAS BASE DE DATOS AQUI EN EL CONTROLADOR , LAS HE HECHO EN LAS CLASES DELO MODELO
    /// </summary>
    public class EmpleosController : Controller
    {
        private ENVASESEntities db = new ENVASESEntities();

        private Empleo varEmpleo = new Empleo();

        // GET: Empleos
        public async Task<ActionResult> Index()
        {
             // return View(await db.Empleos.ToListAsync());
             return View(await varEmpleo.List());
        }

        // GET: Empleos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           // Empleo empleo = await db.Empleos.FindAsync(id);
            Empleo empleo = await varEmpleo.Details(id);
            if (empleo == null)
            {
                return HttpNotFound();
            }
            return View(empleo);
        }

        // GET: Empleos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nombre")] Empleo empleo)
        {
            if (ModelState.IsValid)
            {
                await varEmpleo.Create(empleo);

                //db.Empleos.Add(empleo);
                //await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(empleo);
        }

        // GET: Empleos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
         //  Empleo empleo = await db.Empleos.FindAsync(id);
            Empleo empleo = await varEmpleo.Details(id);
            if (empleo == null)
            {
                return HttpNotFound();
            }
            return View(empleo);
        }

        // POST: Empleos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre")] Empleo empleo)
        {
            if (ModelState.IsValid)
            {
                await varEmpleo.EditByEmpleo(empleo);
                //db.Entry(empleo).State = EntityState.Modified;
                //await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(empleo);
        }

        // GET: Empleos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Empleo empleo = await db.Empleos.FindAsync(id);
            Empleo empleo = await varEmpleo.Details(id);
            if (empleo == null)
            {
                return HttpNotFound();
            }
            return View(empleo);
        }

        // POST: Empleos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Empleo empleo = await varEmpleo.Details(id);
            if (empleo != null)
                await varEmpleo.DeleteByEmpleo(empleo);

            //Empleo empleo = await db.Empleos.FindAsync(id);
            //db.Empleos.Remove(empleo);
            //await db.SaveChangesAsync();
            return RedirectToAction("Index");

            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
