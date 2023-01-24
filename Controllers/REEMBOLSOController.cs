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
    public class REEMBOLSOController : Controller
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        // GET: REEMBOLSO
        public ActionResult Index()
        {
            var rEEMBOLSOes = db.REEMBOLSOs.Include(r => r.PERSONA_NATURAL);
            return View(rEEMBOLSOes.ToList());
        }

        // GET: REEMBOLSO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REEMBOLSO rEEMBOLSO = db.REEMBOLSOs.Find(id);
            if (rEEMBOLSO == null)
            {
                return HttpNotFound();
            }
            return View(rEEMBOLSO);
        }

        // GET: REEMBOLSO/Create
        public ActionResult Create()
        {
            ViewBag.PERSONA_NATURALID = new SelectList(db.PERSONA_NATURALes, "ID", "APELLIDO_PATERNO");
            return View();
        }

        // POST: REEMBOLSO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ESTADO,DESCRIPCION,ESTADO_REEMBOLSO,FECHA,DETALLE,MONTO,TOTAL,PERSONA_NATURALID")] REEMBOLSO rEEMBOLSO)
        {
            if (ModelState.IsValid)
            {
                db.REEMBOLSOs.Add(rEEMBOLSO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PERSONA_NATURALID = new SelectList(db.PERSONA_NATURALes, "ID", "APELLIDO_PATERNO", rEEMBOLSO.PERSONA_NATURALID);
            return View(rEEMBOLSO);
        }

        // GET: REEMBOLSO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REEMBOLSO rEEMBOLSO = db.REEMBOLSOs.Find(id);
            if (rEEMBOLSO == null)
            {
                return HttpNotFound();
            }
            ViewBag.PERSONA_NATURALID = new SelectList(db.PERSONA_NATURALes, "ID", "APELLIDO_PATERNO", rEEMBOLSO.PERSONA_NATURALID);
            return View(rEEMBOLSO);
        }

        // POST: REEMBOLSO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ESTADO,DESCRIPCION,ESTADO_REEMBOLSO,FECHA,DETALLE,MONTO,TOTAL,PERSONA_NATURALID")] REEMBOLSO rEEMBOLSO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rEEMBOLSO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PERSONA_NATURALID = new SelectList(db.PERSONA_NATURALes, "ID", "APELLIDO_PATERNO", rEEMBOLSO.PERSONA_NATURALID);
            return View(rEEMBOLSO);
        }

        // GET: REEMBOLSO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REEMBOLSO rEEMBOLSO = db.REEMBOLSOs.Find(id);
            if (rEEMBOLSO == null)
            {
                return HttpNotFound();
            }
            return View(rEEMBOLSO);
        }

        // POST: REEMBOLSO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            REEMBOLSO rEEMBOLSO = db.REEMBOLSOs.Find(id);
            db.REEMBOLSOs.Remove(rEEMBOLSO);
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
