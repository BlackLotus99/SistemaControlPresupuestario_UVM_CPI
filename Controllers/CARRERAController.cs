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
    public class CARRERAController : Controller
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        // GET: CARRERA
        public ActionResult Index()
        {
            var cARRERAs = db.CARRERAs.Include(c => c.CONSOLIDADO);
            return View(cARRERAs.ToList());
        }

        // GET: CARRERA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARRERA cARRERA = db.CARRERAs.Find(id);
            if (cARRERA == null)
            {
                return HttpNotFound();
            }
            return View(cARRERA);
        }

        // GET: CARRERA/Create
        public ActionResult Create()
        {
            ViewBag.CONSOLIDADOID = new SelectList(db.CONSOLIDADOs, "ID", "MONTO");
            return View();
        }

        // POST: CARRERA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CONSOLIDADOID,ESTADO,NOMBRE,U_EXPLOTACION,DEPARTAMENTO,PROD_TITULO,DISCIPLINA")] CARRERA cARRERA)
        {
            if (ModelState.IsValid)
            {
                db.CARRERAs.Add(cARRERA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CONSOLIDADOID = new SelectList(db.CONSOLIDADOs, "ID", "MONTO", cARRERA.CONSOLIDADOID);
            return View(cARRERA);
        }

        // GET: CARRERA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARRERA cARRERA = db.CARRERAs.Find(id);
            if (cARRERA == null)
            {
                return HttpNotFound();
            }
            ViewBag.CONSOLIDADOID = new SelectList(db.CONSOLIDADOs, "ID", "MONTO", cARRERA.CONSOLIDADOID);
            return View(cARRERA);
        }

        // POST: CARRERA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CONSOLIDADOID,ESTADO,NOMBRE,U_EXPLOTACION,DEPARTAMENTO,PROD_TITULO,DISCIPLINA")] CARRERA cARRERA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cARRERA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CONSOLIDADOID = new SelectList(db.CONSOLIDADOs, "ID", "MONTO", cARRERA.CONSOLIDADOID);
            return View(cARRERA);
        }

        // GET: CARRERA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARRERA cARRERA = db.CARRERAs.Find(id);
            if (cARRERA == null)
            {
                return HttpNotFound();
            }
            return View(cARRERA);
        }

        // POST: CARRERA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CARRERA cARRERA = db.CARRERAs.Find(id);
            db.CARRERAs.Remove(cARRERA);
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
