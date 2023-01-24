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
    public class BOLETAController : Controller
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        // GET: BOLETA
        public ActionResult Index()
        {
            var bOLETAs = db.BOLETAs.Include(b => b.OPEX).Include(b => b.CAPEX);
            return View(bOLETAs.ToList());
        }

        // GET: BOLETA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOLETA bOLETA = db.BOLETAs.Find(id);
            if (bOLETA == null)
            {
                return HttpNotFound();
            }
            return View(bOLETA);
        }

        // GET: BOLETA/Create
        public ActionResult Create()
        {
            ViewBag.OPEXID = new SelectList(db.OPEXes, "ID", "MONTO_NETO");
            ViewBag.CAPEXID = new SelectList(db.CAPEXes, "ID", "DETALLE");
            return View();
        }

        // POST: BOLETA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NUMERO_BOLETA,FECHA_BOLETA,MONTO,DETALLE,OPEXID,CAPEXID")] BOLETA bOLETA)
        {
            if (ModelState.IsValid)
            {
                db.BOLETAs.Add(bOLETA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OPEXID = new SelectList(db.OPEXes, "ID", "MONTO_NETO", bOLETA.OPEXID);
            ViewBag.CAPEXID = new SelectList(db.CAPEXes, "ID", "DETALLE", bOLETA.CAPEXID);
            return View(bOLETA);
        }

        // GET: BOLETA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOLETA bOLETA = db.BOLETAs.Find(id);
            if (bOLETA == null)
            {
                return HttpNotFound();
            }
            ViewBag.OPEXID = new SelectList(db.OPEXes, "ID", "MONTO_NETO", bOLETA.OPEXID);
            ViewBag.CAPEXID = new SelectList(db.CAPEXes, "ID", "DETALLE", bOLETA.CAPEXID);
            return View(bOLETA);
        }

        // POST: BOLETA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NUMERO_BOLETA,FECHA_BOLETA,MONTO,DETALLE,OPEXID,CAPEXID")] BOLETA bOLETA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bOLETA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OPEXID = new SelectList(db.OPEXes, "ID", "MONTO_NETO", bOLETA.OPEXID);
            ViewBag.CAPEXID = new SelectList(db.CAPEXes, "ID", "DETALLE", bOLETA.CAPEXID);
            return View(bOLETA);
        }

        // GET: BOLETA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOLETA bOLETA = db.BOLETAs.Find(id);
            if (bOLETA == null)
            {
                return HttpNotFound();
            }
            return View(bOLETA);
        }

        // POST: BOLETA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BOLETA bOLETA = db.BOLETAs.Find(id);
            db.BOLETAs.Remove(bOLETA);
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
