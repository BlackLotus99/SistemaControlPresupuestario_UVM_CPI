using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sistema_UVM_Control_Presupuestario;
using Sistema_UVM_Control_Presupuestario.Servicios;

namespace Sistema_UVM_Control_Presupuestario.Controllers
{
    public class PERSONA_NATURALController : Controller
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        // GET: PERSONA_NATURAL
        public ActionResult Index()
        {
            //return View(db.PERSONA_NATURALes.ToList());
            return View(new PERSONA_NATURAL_SRV().Listar(););
        }

        // GET: PERSONA_NATURAL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PERSONA_NATURALes pERSONA_NATURAL = db.PERSONA_NATURALes.Find(id);
            PERSONA_NATURALes pERSONA_NATURAL = new PERSONA_NATURAL_SRV().Buscar(id);
            if (pERSONA_NATURAL == null)
            {
                return HttpNotFound();
            }
            return View(pERSONA_NATURAL);
        }

        // GET: PERSONA_NATURAL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PERSONA_NATURAL/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,APELLIDO_PATERNO,APELLIDO_MATERNO,ID_EMPLEADO,CORREO,ESTADO,NOMBRE,RUT,DIGITO_VERIFICADOR")] PERSONA_NATURALes pERSONA_NATURAL)
        {
            if (ModelState.IsValid)
            {
                //db.PERSONA_NATURALes.Add(pERSONA_NATURAL);
                //db.SaveChanges();
                new PERSONA_NATURAL_SRV().Agregar(pERSONA_NATURAL);
                return RedirectToAction("Index");
            }

            return View(pERSONA_NATURAL);
        }

        // GET: PERSONA_NATURAL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PERSONA_NATURALes pERSONA_NATURAL = db.PERSONA_NATURALes.Find(id);
            PERSONA_NATURALes pERSONA_NATURAL = new PERSONA_NATURAL_SRV().Buscar(id);
            if (pERSONA_NATURAL == null)
            {
                return HttpNotFound();
            }
            return View(pERSONA_NATURAL);
        }

        // POST: PERSONA_NATURAL/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,APELLIDO_PATERNO,APELLIDO_MATERNO,ID_EMPLEADO,CORREO,ESTADO,NOMBRE,RUT,DIGITO_VERIFICADOR")] PERSONA_NATURALes pERSONA_NATURAL)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(pERSONA_NATURAL).State = EntityState.Modified;
                //db.SaveChanges();
                new PERSONA_NATURAL_SRV().Editar(pERSONA_NATURAL);
                return RedirectToAction("Index");
            }
            return View(pERSONA_NATURAL);
        }

        // GET: PERSONA_NATURAL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PERSONA_NATURALes pERSONA_NATURAL = db.PERSONA_NATURALes.Find(id);
            PERSONA_NATURALes pERSONA_NATURAL = new PERSONA_NATURAL_SRV().Buscar(id);
            if (pERSONA_NATURAL == null)
            {
                return HttpNotFound();
            }
            return View(pERSONA_NATURAL);
        }

        // POST: PERSONA_NATURAL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //PERSONA_NATURALes pERSONA_NATURAL = db.PERSONA_NATURALes.Find(id);
            //db.PERSONA_NATURALes.Remove(pERSONA_NATURAL);
            //db.SaveChanges();
            new PERSONA_NATURAL_SRV().Eliminar(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                new PERSONA_NATURAL_SRV().Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
