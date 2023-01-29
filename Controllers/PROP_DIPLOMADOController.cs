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
    public class PROP_DIPLOMADOController : Controller
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        // GET: PROP_DIPLOMADO
        public ActionResult Index()
        {
            //var pROP_DIPLOMADO = db.PROP_DIPLOMADOs.Include(p => p.PERSONA_NATURAL);
            //return View(pROP_DIPLOMADO.ToList());
            return View(new PROP_DIPLOMADO_SRV().Listar());
        }

        // GET: PROP_DIPLOMADO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PROP_DIPLOMADO pROP_DIPLOMADO = db.PROP_DIPLOMADOs.Find(id);
            PROP_DIPLOMADO pROP_DIPLOMADO = new PROP_DIPLOMADO_SRV().Buscar(id);
            if (pROP_DIPLOMADO == null)
            {
                return HttpNotFound();
            }
            return View(pROP_DIPLOMADO);
        }

        // GET: PROP_DIPLOMADO/Create
        public ActionResult Create()
        {
            ViewBag.PERSONA_NATURALID = new SelectList(db.PERSONA_NATURALes, "ID", "APELLIDO_PATERNO");
            return View();
        }

        // POST: PROP_DIPLOMADO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ESTADO,RESPONSABLE,MODALIDAD,FECHA_INICIO,FECHA_TERMINO,PERSONA_NATURALID,CANTIDAD_MODULO,CANTIDAD_ALUMNO,COSTO,INGRESO_NETO,COSTO_DOCENTE,COSTO_ACADEMICO,OTROS_COSTOS,TOTAL")] PROP_DIPLOMADO pROP_DIPLOMADO)
        {
            if (ModelState.IsValid)
            {
                //db.PROP_DIPLOMADOs.Add(pROP_DIPLOMADO);
                //db.SaveChanges();
                new PROP_DIPLOMADO_SRV().Agregar(pROP_DIPLOMADO);
                return RedirectToAction("Index");
            }

            ViewBag.PERSONA_NATURALID = new SelectList(db.PERSONA_NATURALes, "ID", "APELLIDO_PATERNO", pROP_DIPLOMADO.PERSONA_NATURALID);
            return View(pROP_DIPLOMADO);
        }

        // GET: PROP_DIPLOMADO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PROP_DIPLOMADO pROP_DIPLOMADO = db.PROP_DIPLOMADOs.Find(id);
            PROP_DIPLOMADO pROP_DIPLOMADO = new PROP_DIPLOMADO_SRV().Buscar(id);
            if (pROP_DIPLOMADO == null)
            {
                return HttpNotFound();
            }
            ViewBag.PERSONA_NATURALID = new SelectList(db.PERSONA_NATURALes, "ID", "APELLIDO_PATERNO", pROP_DIPLOMADO.PERSONA_NATURALID);
            return View(pROP_DIPLOMADO);
        }

        // POST: PROP_DIPLOMADO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ESTADO,RESPONSABLE,MODALIDAD,FECHA_INICIO,FECHA_TERMINO,PERSONA_NATURALID,CANTIDAD_MODULO,CANTIDAD_ALUMNO,COSTO,INGRESO_NETO,COSTO_DOCENTE,COSTO_ACADEMICO,OTROS_COSTOS,TOTAL")] PROP_DIPLOMADO pROP_DIPLOMADO)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(pROP_DIPLOMADO).State = EntityState.Modified;
                //db.SaveChanges();
                new PROP_DIPLOMADO_SRV().Editar(pROP_DIPLOMADO);
                return RedirectToAction("Index");
            }
            ViewBag.PERSONA_NATURALID = new SelectList(db.PERSONA_NATURALes, "ID", "APELLIDO_PATERNO", pROP_DIPLOMADO.PERSONA_NATURALID);
            return View(pROP_DIPLOMADO);
        }

        // GET: PROP_DIPLOMADO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PROP_DIPLOMADO pROP_DIPLOMADO = db.PROP_DIPLOMADOs.Find(id);
            PROP_DIPLOMADO pROP_DIPLOMADO = new PROP_DIPLOMADO_SRV().Buscar(id);
            if (pROP_DIPLOMADO == null)
            {
                return HttpNotFound();
            }
            return View(pROP_DIPLOMADO);
        }

        // POST: PROP_DIPLOMADO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //PROP_DIPLOMADO pROP_DIPLOMADO = db.PROP_DIPLOMADOs.Find(id);
            //db.PROP_DIPLOMADOs.Remove(pROP_DIPLOMADO);
            //db.SaveChanges();
            new PROP_DIPLOMADO_SRV().Eliminar(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                new PROP_DIPLOMADO_SRV().Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
