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
    public class SOLICITUDController : Controller
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        // GET: SOLICITUD
        public ActionResult Index()
        {
            var sOLICITUDs = db.SOLICITUDs.Include(s => s.CAPEX).Include(s => s.OPEX).Include(s => s.PERSONA_JURIDICA);
            return View(sOLICITUDs.ToList());
        }

        // GET: SOLICITUD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOLICITUD sOLICITUD = db.SOLICITUDs.Find(id);
            if (sOLICITUD == null)
            {
                return HttpNotFound();
            }
            return View(sOLICITUD);
        }

        // GET: SOLICITUD/Create
        public ActionResult Create()
        {
            ViewBag.CAPEXID = new SelectList(db.CAPEXes, "ID", "DETALLE");
            ViewBag.OPEXID = new SelectList(db.OPEXes, "ID", "MONTO_NETO");
            ViewBag.PERSONA_JURIDICAID = new SelectList(db.PERSONA_JURIDICAs, "ID", "NOMBRE");
            return View();
        }

        // POST: SOLICITUD/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NUMERO_SOLICITUD,DETALLE,PERSONA_JURIDICAID,CAPEXID,OPEXID")] SOLICITUD sOLICITUD)
        {
            if (ModelState.IsValid)
            {
                db.SOLICITUDs.Add(sOLICITUD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CAPEXID = new SelectList(db.CAPEXes, "ID", "DETALLE", sOLICITUD.CAPEXID);
            ViewBag.OPEXID = new SelectList(db.OPEXes, "ID", "MONTO_NETO", sOLICITUD.OPEXID);
            ViewBag.PERSONA_JURIDICAID = new SelectList(db.PERSONA_JURIDICAs, "ID", "NOMBRE", sOLICITUD.PERSONA_JURIDICAID);
            return View(sOLICITUD);
        }

        // GET: SOLICITUD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOLICITUD sOLICITUD = db.SOLICITUDs.Find(id);
            if (sOLICITUD == null)
            {
                return HttpNotFound();
            }
            ViewBag.CAPEXID = new SelectList(db.CAPEXes, "ID", "DETALLE", sOLICITUD.CAPEXID);
            ViewBag.OPEXID = new SelectList(db.OPEXes, "ID", "MONTO_NETO", sOLICITUD.OPEXID);
            ViewBag.PERSONA_JURIDICAID = new SelectList(db.PERSONA_JURIDICAs, "ID", "NOMBRE", sOLICITUD.PERSONA_JURIDICAID);
            return View(sOLICITUD);
        }

        // POST: SOLICITUD/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NUMERO_SOLICITUD,DETALLE,PERSONA_JURIDICAID,CAPEXID,OPEXID")] SOLICITUD sOLICITUD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sOLICITUD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CAPEXID = new SelectList(db.CAPEXes, "ID", "DETALLE", sOLICITUD.CAPEXID);
            ViewBag.OPEXID = new SelectList(db.OPEXes, "ID", "MONTO_NETO", sOLICITUD.OPEXID);
            ViewBag.PERSONA_JURIDICAID = new SelectList(db.PERSONA_JURIDICAs, "ID", "NOMBRE", sOLICITUD.PERSONA_JURIDICAID);
            return View(sOLICITUD);
        }

        // GET: SOLICITUD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOLICITUD sOLICITUD = db.SOLICITUDs.Find(id);
            if (sOLICITUD == null)
            {
                return HttpNotFound();
            }
            return View(sOLICITUD);
        }

        // POST: SOLICITUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SOLICITUD sOLICITUD = db.SOLICITUDs.Find(id);
            db.SOLICITUDs.Remove(sOLICITUD);
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
