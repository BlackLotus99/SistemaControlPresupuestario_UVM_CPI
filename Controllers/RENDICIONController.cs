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
    public class RENDICIONController : Controller
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        // GET: RENDICION
        public ActionResult Index()
        {
            var rENDICIONs = db.RENDICIONs.Include(r => r.PERSONA_JURIDICA).Include(r => r.PERSONA_NATURAL);
            return View(rENDICIONs.ToList());
        }

        // GET: RENDICION/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RENDICION rENDICION = db.RENDICIONs.Find(id);
            if (rENDICION == null)
            {
                return HttpNotFound();
            }
            return View(rENDICION);
        }

        // GET: RENDICION/Create
        public ActionResult Create()
        {
            ViewBag.PERSONA_JURIDICAID = new SelectList(db.PERSONA_JURIDICAs, "ID", "NOMBRE");
            ViewBag.PERSONA_NATURALID = new SelectList(db.PERSONA_NATURALes, "ID", "APELLIDO_PATERNO");
            return View();
        }

        // POST: RENDICION/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ESTADO,DESCRIPCION,ESTADO_ANTICIPO,FECHA,ID_RENDICION,DETALLE_VARIOS,PERSONA_NATURALID,PERSONA_JURIDICAID")] RENDICION rENDICION)
        {
            if (ModelState.IsValid)
            {
                db.RENDICIONs.Add(rENDICION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PERSONA_JURIDICAID = new SelectList(db.PERSONA_JURIDICAs, "ID", "NOMBRE", rENDICION.PERSONA_JURIDICAID);
            ViewBag.PERSONA_NATURALID = new SelectList(db.PERSONA_NATURALes, "ID", "APELLIDO_PATERNO", rENDICION.PERSONA_NATURALID);
            return View(rENDICION);
        }

        // GET: RENDICION/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RENDICION rENDICION = db.RENDICIONs.Find(id);
            if (rENDICION == null)
            {
                return HttpNotFound();
            }
            ViewBag.PERSONA_JURIDICAID = new SelectList(db.PERSONA_JURIDICAs, "ID", "NOMBRE", rENDICION.PERSONA_JURIDICAID);
            ViewBag.PERSONA_NATURALID = new SelectList(db.PERSONA_NATURALes, "ID", "APELLIDO_PATERNO", rENDICION.PERSONA_NATURALID);
            return View(rENDICION);
        }

        // POST: RENDICION/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ESTADO,DESCRIPCION,ESTADO_ANTICIPO,FECHA,ID_RENDICION,DETALLE_VARIOS,PERSONA_NATURALID,PERSONA_JURIDICAID")] RENDICION rENDICION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rENDICION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PERSONA_JURIDICAID = new SelectList(db.PERSONA_JURIDICAs, "ID", "NOMBRE", rENDICION.PERSONA_JURIDICAID);
            ViewBag.PERSONA_NATURALID = new SelectList(db.PERSONA_NATURALes, "ID", "APELLIDO_PATERNO", rENDICION.PERSONA_NATURALID);
            return View(rENDICION);
        }

        // GET: RENDICION/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RENDICION rENDICION = db.RENDICIONs.Find(id);
            if (rENDICION == null)
            {
                return HttpNotFound();
            }
            return View(rENDICION);
        }

        // POST: RENDICION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RENDICION rENDICION = db.RENDICIONs.Find(id);
            db.RENDICIONs.Remove(rENDICION);
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
