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
    public class MAGISTERController : Controller
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        // GET: MAGISTER
        public ActionResult Index()
        {
            //var mAGISTERs = db.MAGISTERs.Include(m => m.CONSOLIDADO);
            //return View(mAGISTERs.ToList());
            return View(new MAGISTER_SRV().Listar());
        }

        // GET: MAGISTER/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //MAGISTER mAGISTER = db.MAGISTERs.Find(id);
            MAGISTER mAGISTER = new MAGISTER_SRV().Buscar(id);
            if (mAGISTER == null)
            {
                return HttpNotFound();
            }
            return View(mAGISTER);
        }

        // GET: MAGISTER/Create
        public ActionResult Create()
        {
            ViewBag.CONSOLIDADOID = new SelectList(db.CONSOLIDADOs, "ID", "MONTO");
            return View();
        }

        // POST: MAGISTER/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CONSOLIDADOID,ESTADO,NOMBRE,U_EXPLOTACION,DEPARTAMENTO,PROD_TITULO,DISCIPLINA")] MAGISTER mAGISTER)
        {
            if (ModelState.IsValid)
            {
                //db.MAGISTERs.Add(mAGISTER);
                //db.SaveChanges();
                new MAGISTER_SRV().Agregar(mAGISTER);
                return RedirectToAction("Index");
            }

            ViewBag.CONSOLIDADOID = new SelectList(db.CONSOLIDADOs, "ID", "MONTO", mAGISTER.CONSOLIDADOID);
            return View(mAGISTER);
        }

        // GET: MAGISTER/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //MAGISTER mAGISTER = db.MAGISTERs.Find(id);
            MAGISTER mAGISTER = new MAGISTER_SRV().Buscar(id);
            if (mAGISTER == null)
            {
                return HttpNotFound();
            }
            ViewBag.CONSOLIDADOID = new SelectList(db.CONSOLIDADOs, "ID", "MONTO", mAGISTER.CONSOLIDADOID);
            return View(mAGISTER);
        }

        // POST: MAGISTER/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CONSOLIDADOID,ESTADO,NOMBRE,U_EXPLOTACION,DEPARTAMENTO,PROD_TITULO,DISCIPLINA")] MAGISTER mAGISTER)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(mAGISTER).State = EntityState.Modified;
                //db.SaveChanges();
                new MAGISTER_SRV().Editar(mAGISTER);
                return RedirectToAction("Index");
            }
            ViewBag.CONSOLIDADOID = new SelectList(db.CONSOLIDADOs, "ID", "MONTO", mAGISTER.CONSOLIDADOID);
            return View(mAGISTER);
        }

        // GET: MAGISTER/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //MAGISTER mAGISTER = db.MAGISTERs.Find(id);
            MAGISTER mAGISTER = new MAGISTER_SRV().Buscar(id);
            if (mAGISTER == null)
            {
                return HttpNotFound();
            }
            return View(mAGISTER);
        }

        // POST: MAGISTER/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //MAGISTER mAGISTER = db.MAGISTERs.Find(id);
            //db.MAGISTERs.Remove(mAGISTER);
            //db.SaveChanges();
            new MAGISTER_SRV().Eliminar(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                new MAGISTER_SRV() .Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
