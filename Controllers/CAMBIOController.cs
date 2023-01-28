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
    public class CAMBIOController : Controller
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        // GET: CAMBIO
        public ActionResult Index()
        {
            return View(new BOLETA_SRV().Listar());
        }

        // GET: CAMBIO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAMBIO cAMBIO = new CAMBIO_SRV().Buscar(id);
            if (cAMBIO == null)
            {
                return HttpNotFound();
            }
            return View(cAMBIO);
        }

        // GET: CAMBIO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CAMBIO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MONEDA_CAMBIO,FECHA")] CAMBIO cAMBIO)
        {
            if (ModelState.IsValid)
            {
                //db.CAMBIOs.Add(cAMBIO);
                //db.SaveChanges();
                new CAMBIO_SRV().Agregar(cAMBIO);
                return RedirectToAction("Index");
            }

            return View(cAMBIO);
        }

        // GET: CAMBIO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAMBIO cAMBIO = new CAMBIO_SRV().Buscar(id);
            if (cAMBIO == null)
            {
                return HttpNotFound();
            }
            return View(cAMBIO);
        }

        // POST: CAMBIO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MONEDA_CAMBIO,FECHA")] CAMBIO cAMBIO)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(cAMBIO).State = EntityState.Modified;
                //db.SaveChanges();
                new CAMBIO_SRV().Editar(cAMBIO);
                return RedirectToAction("Index");
            }
            return View(cAMBIO);
        }

        // GET: CAMBIO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAMBIO cAMBIO = db.CAMBIOs.Find(id);
            if (cAMBIO == null)
            {
                return HttpNotFound();
            }
            return View(cAMBIO);
        }

        // POST: CAMBIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //CAMBIO cAMBIO = db.CAMBIOs.Find(id);
            //db.CAMBIOs.Remove(cAMBIO);
            //db.SaveChanges();
            new CAMBIO_SRV().Eliminar(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                new CAMBIO_SRV().Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
