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
    public class FACTURAController : Controller
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        // GET: FACTURA
        public ActionResult Index()
        {
            var fACTURAs = db.FACTURAs.Include(f => f.OPEX).Include(f => f.CAPEX);
            return View(fACTURAs.ToList());
        }

        // GET: FACTURA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURA fACTURA = db.FACTURAs.Find(id);
            if (fACTURA == null)
            {
                return HttpNotFound();
            }
            return View(fACTURA);
        }

        // GET: FACTURA/Create
        public ActionResult Create()
        {
            ViewBag.OPEXID = new SelectList(db.OPEXes, "ID", "MONTO_NETO");
            ViewBag.CAPEXID = new SelectList(db.CAPEXes, "ID", "DETALLE");
            return View();
        }

        // POST: FACTURA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NUMERO_FACTURA,FECHA_FACTURA,MONTO,DETALLE,OPEXID,CAPEXID")] FACTURA fACTURA)
        {
            if (ModelState.IsValid)
            {
                db.FACTURAs.Add(fACTURA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OPEXID = new SelectList(db.OPEXes, "ID", "MONTO_NETO", fACTURA.OPEXID);
            ViewBag.CAPEXID = new SelectList(db.CAPEXes, "ID", "DETALLE", fACTURA.CAPEXID);
            return View(fACTURA);
        }

        // GET: FACTURA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURA fACTURA = db.FACTURAs.Find(id);
            if (fACTURA == null)
            {
                return HttpNotFound();
            }
            ViewBag.OPEXID = new SelectList(db.OPEXes, "ID", "MONTO_NETO", fACTURA.OPEXID);
            ViewBag.CAPEXID = new SelectList(db.CAPEXes, "ID", "DETALLE", fACTURA.CAPEXID);
            return View(fACTURA);
        }

        // POST: FACTURA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NUMERO_FACTURA,FECHA_FACTURA,MONTO,DETALLE,OPEXID,CAPEXID")] FACTURA fACTURA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fACTURA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OPEXID = new SelectList(db.OPEXes, "ID", "MONTO_NETO", fACTURA.OPEXID);
            ViewBag.CAPEXID = new SelectList(db.CAPEXes, "ID", "DETALLE", fACTURA.CAPEXID);
            return View(fACTURA);
        }

        // GET: FACTURA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURA fACTURA = db.FACTURAs.Find(id);
            if (fACTURA == null)
            {
                return HttpNotFound();
            }
            return View(fACTURA);
        }

        // POST: FACTURA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FACTURA fACTURA = db.FACTURAs.Find(id);
            db.FACTURAs.Remove(fACTURA);
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
