using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sistema_UVM_Control_Presupuestario;

namespace Sistema_UVM_Control_Presupuestario.Controllers
{
    public class PAGO_DIPLOMADOController : Controller
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        // GET: PAGO_DIPLOMADO
        public ActionResult Index()
        {
            var pAGO_DIPLOMADO = db.PAGO_DIPLOMADOs.Include(p => p.PERSONA_NATURAL);
            return View(pAGO_DIPLOMADO.ToList());
        }

        // GET: PAGO_DIPLOMADO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAGO_DIPLOMADO pAGO_DIPLOMADO = db.PAGO_DIPLOMADOs.Find(id);
            if (pAGO_DIPLOMADO == null)
            {
                return HttpNotFound();
            }
            return View(pAGO_DIPLOMADO);
        }

        // GET: PAGO_DIPLOMADO/Create
        public ActionResult Create()
        {
            ViewBag.PERSONA_NATURALID = new SelectList(db.PERSONA_NATURALes, "ID", "APELLIDO_PATERNO");
            return View();
        }

        // POST: PAGO_DIPLOMADO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ESTADO,PERSONA_NATURALID,PROGRAMA,MOTIVO,TOTAL")] PAGO_DIPLOMADO pAGO_DIPLOMADO)
        {
            if (ModelState.IsValid)
            {
                db.PAGO_DIPLOMADOs.Add(pAGO_DIPLOMADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PERSONA_NATURALID = new SelectList(db.PERSONA_NATURALes, "ID", "APELLIDO_PATERNO", pAGO_DIPLOMADO.PERSONA_NATURALID);
            return View(pAGO_DIPLOMADO);
        }

        // GET: PAGO_DIPLOMADO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAGO_DIPLOMADO pAGO_DIPLOMADO = db.PAGO_DIPLOMADOs.Find(id);
            if (pAGO_DIPLOMADO == null)
            {
                return HttpNotFound();
            }
            ViewBag.PERSONA_NATURALID = new SelectList(db.PERSONA_NATURALes, "ID", "APELLIDO_PATERNO", pAGO_DIPLOMADO.PERSONA_NATURALID);
            return View(pAGO_DIPLOMADO);
        }

        // POST: PAGO_DIPLOMADO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ESTADO,PERSONA_NATURALID,PROGRAMA,MOTIVO,TOTAL")] PAGO_DIPLOMADO pAGO_DIPLOMADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pAGO_DIPLOMADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PERSONA_NATURALID = new SelectList(db.PERSONA_NATURALes, "ID", "APELLIDO_PATERNO", pAGO_DIPLOMADO.PERSONA_NATURALID);
            return View(pAGO_DIPLOMADO);
        }

        // GET: PAGO_DIPLOMADO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAGO_DIPLOMADO pAGO_DIPLOMADO = db.PAGO_DIPLOMADOs.Find(id);
            if (pAGO_DIPLOMADO == null)
            {
                return HttpNotFound();
            }
            return View(pAGO_DIPLOMADO);
        }

        // POST: PAGO_DIPLOMADO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PAGO_DIPLOMADO pAGO_DIPLOMADO = db.PAGO_DIPLOMADOs.Find(id);
            db.PAGO_DIPLOMADOs.Remove(pAGO_DIPLOMADO);
            db.SaveChanges();
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
