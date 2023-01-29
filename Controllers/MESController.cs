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
    public class MESController : Controller
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        // GET: MES
        public ActionResult Index()
        {
            //var mESes = db.MEs.Include(m => m.CONSOLIDADO);
            //return View(mESes.ToList());
            return View(new MES_SRV().Listar());
        }

        // GET: MES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //MES mES = db.MEs.Find(id);
            MES mES = new MES_SRV().Buscar(id);
            if (mES == null)
            {
                return HttpNotFound();
            }
            return View(mES);
        }

        // GET: MES/Create
        public ActionResult Create()
        {
            ViewBag.CONSOLIDADOID = new SelectList(db.CONSOLIDADOs, "ID", "MONTO");
            return View();
        }

        // POST: MES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE_MES,CONSOLIDADOID")] MES mES)
        {
            if (ModelState.IsValid)
            {
                //db.MEs.Add(mES);
                //db.SaveChanges();
                new MES_SRV().Agregar(mES);
                return RedirectToAction("Index");
            }

            ViewBag.CONSOLIDADOID = new SelectList(db.CONSOLIDADOs, "ID", "MONTO", mES.CONSOLIDADOID);
            return View(mES);
        }

        // GET: MES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //MES mES = db.MEs.Find(id);
            MES mES = new MES_SRV().Buscar(id);
            if (mES == null)
            {
                return HttpNotFound();
            }
            ViewBag.CONSOLIDADOID = new SelectList(db.CONSOLIDADOs, "ID", "MONTO", mES.CONSOLIDADOID);
            return View(mES);
        }

        // POST: MES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE_MES,CONSOLIDADOID")] MES mES)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(mES).State = EntityState.Modified;
                //db.SaveChanges();
                new MES_SRV().Editar(mES);
                return RedirectToAction("Index");
            }
            ViewBag.CONSOLIDADOID = new SelectList(db.CONSOLIDADOs, "ID", "MONTO", mES.CONSOLIDADOID);
            return View(mES);
        }

        // GET: MES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //MES mES = db.MEs.Find(id);
            MES mES = new MES_SRV().Buscar(id);
            if (mES == null)
            {
                return HttpNotFound();
            }
            return View(mES);
        }

        // POST: MES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //MES mES = db.MEs.Find(id);
            //db.MEs.Remove(mES);
            //db.SaveChanges();
            new MES_SRV().Eliminar(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                new MES_SRV().Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
