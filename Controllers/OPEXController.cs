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
    public class OPEXController : Controller
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        // GET: OPEX
        public ActionResult Index()
        {
            var oPEXes = db.OPEXes.Include(o => o.PERSONA_NATURAL);
            return View(oPEXes.ToList());
        }

        // GET: OPEX/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPEX oPEX = db.OPEXes.Find(id);
            if (oPEX == null)
            {
                return HttpNotFound();
            }
            return View(oPEX);
        }

        // GET: OPEX/Create
        public ActionResult Create()
        {
            ViewBag.PERSONA_NATURALID = new SelectList(db.PERSONA_NATURALes, "ID", "APELLIDO_PATERNO");
            return View();
        }

        // POST: OPEX/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ESTADO,PERSONA_NATURALID,MONTO_NETO,IVA,TOTAL,ESTADO_OPEX,RECEPCION,VALIDACION")] OPEX oPEX)
        {
            if (ModelState.IsValid)
            {
                db.OPEXes.Add(oPEX);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PERSONA_NATURALID = new SelectList(db.PERSONA_NATURALes, "ID", "APELLIDO_PATERNO", oPEX.PERSONA_NATURALID);
            return View(oPEX);
        }

        // GET: OPEX/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPEX oPEX = db.OPEXes.Find(id);
            if (oPEX == null)
            {
                return HttpNotFound();
            }
            ViewBag.PERSONA_NATURALID = new SelectList(db.PERSONA_NATURALes, "ID", "APELLIDO_PATERNO", oPEX.PERSONA_NATURALID);
            return View(oPEX);
        }

        // POST: OPEX/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ESTADO,PERSONA_NATURALID,MONTO_NETO,IVA,TOTAL,ESTADO_OPEX,RECEPCION,VALIDACION")] OPEX oPEX)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oPEX).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PERSONA_NATURALID = new SelectList(db.PERSONA_NATURALes, "ID", "APELLIDO_PATERNO", oPEX.PERSONA_NATURALID);
            return View(oPEX);
        }

        // GET: OPEX/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPEX oPEX = db.OPEXes.Find(id);
            if (oPEX == null)
            {
                return HttpNotFound();
            }
            return View(oPEX);
        }

        // POST: OPEX/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OPEX oPEX = db.OPEXes.Find(id);
            db.OPEXes.Remove(oPEX);
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
