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
    public class PROGRAMAController : Controller
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        // GET: PROGRAMA
        public ActionResult Index()
        {
            return View(db.PROGRAMAs.ToList());
        }

        // GET: PROGRAMA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROGRAMA pROGRAMA = db.PROGRAMAs.Find(id);
            if (pROGRAMA == null)
            {
                return HttpNotFound();
            }
            return View(pROGRAMA);
        }

        // GET: PROGRAMA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PROGRAMA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ESTADO,NOMBRE,U_EXPLOTACION,DEPARTAMENTO,PROD_TITULO,DISCIPLINA")] PROGRAMA pROGRAMA)
        {
            if (ModelState.IsValid)
            {
                db.PROGRAMAs.Add(pROGRAMA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pROGRAMA);
        }

        // GET: PROGRAMA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROGRAMA pROGRAMA = db.PROGRAMAs.Find(id);
            if (pROGRAMA == null)
            {
                return HttpNotFound();
            }
            return View(pROGRAMA);
        }

        // POST: PROGRAMA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ESTADO,NOMBRE,U_EXPLOTACION,DEPARTAMENTO,PROD_TITULO,DISCIPLINA")] PROGRAMA pROGRAMA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROGRAMA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pROGRAMA);
        }

        // GET: PROGRAMA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROGRAMA pROGRAMA = db.PROGRAMAs.Find(id);
            if (pROGRAMA == null)
            {
                return HttpNotFound();
            }
            return View(pROGRAMA);
        }

        // POST: PROGRAMA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PROGRAMA pROGRAMA = db.PROGRAMAs.Find(id);
            db.PROGRAMAs.Remove(pROGRAMA);
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
