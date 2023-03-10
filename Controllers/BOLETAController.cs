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
    public class BOLETAController : Controller
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        // GET: BOLETA
        public ActionResult Index()
        {
            return View(new BOLETA_SRV().Listar());
        }

        // GET: BOLETA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOLETA boleta = new BOLETA_SRV().Buscar(id);
            if (boleta == null)
            {
                return HttpNotFound();
            }
            return View(boleta);
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
                new BOLETA_SRV().Agregar(bOLETA);
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
            //BOLETA bOLETA = db.BOLETAs.Find(id);
            BOLETA boleta = new BOLETA_SRV().Buscar(id);
            if (boleta == null)
            {
                return HttpNotFound();
            }
            ViewBag.OPEXID = new SelectList(db.OPEXes, "ID", "MONTO_NETO", boleta.OPEXID);
            ViewBag.CAPEXID = new SelectList(db.CAPEXes, "ID", "DETALLE", boleta.CAPEXID);
            return View(boleta);
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
                //db.Entry(bOLETA).State = EntityState.Modified;
                //db.SaveChanges();
                new BOLETA_SRV().Editar(bOLETA);
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
            BOLETA boleta = new BOLETA_SRV().Buscar(id);
            if (boleta == null)
            {
                return HttpNotFound();
            }
            return View(boleta);
        }

        // POST: BOLETA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //BOLETA bOLETA = db.BOLETAs.Find(id);
            //db.BOLETAs.Remove(bOLETA);
            //db.SaveChanges();
            new BOLETA_SRV().Eliminar(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                new BOLETA_SRV().Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
