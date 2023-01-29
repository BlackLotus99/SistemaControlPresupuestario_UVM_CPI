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
    public class CONSOLIDADOController : Controller
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        // GET: CONSOLIDADO
        public ActionResult Index()
        {
            //return View(db.CONSOLIDADOs.ToList());
            return View(new CONSOLIDADO_SRV().Listar());
        }

        // GET: CONSOLIDADO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CONSOLIDADO cONSOLIDADO = db.CONSOLIDADOs.Find(id);
            CONSOLIDADO cONSOLIDADO = new CONSOLIDADO_SRV().Buscar(id);
            if (cONSOLIDADO == null)
            {
                return HttpNotFound();
            }
            return View(cONSOLIDADO);
        }

        // GET: CONSOLIDADO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CONSOLIDADO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ESTADO,MONTO,TOTAL")] CONSOLIDADO cONSOLIDADO)
        {
            if (ModelState.IsValid)
            {
                //db.CONSOLIDADOs.Add(cONSOLIDADO);
                //db.SaveChanges();
                new CONSOLIDADO_SRV().Agregar(cONSOLIDADO);
                return RedirectToAction("Index");
            }

            return View(cONSOLIDADO);
        }

        // GET: CONSOLIDADO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CONSOLIDADO cONSOLIDADO = db.CONSOLIDADOs.Find(id);
            CONSOLIDADO cONSOLIDADO = new CONSOLIDADO_SRV().Buscar(id);
            if (cONSOLIDADO == null)
            {
                return HttpNotFound();
            }
            return View(cONSOLIDADO);
        }

        // POST: CONSOLIDADO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ESTADO,MONTO,TOTAL")] CONSOLIDADO cONSOLIDADO)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(cONSOLIDADO).State = EntityState.Modified;
                //db.SaveChanges();
                new CONSOLIDADO_SRV().Editar(cONSOLIDADO);
                return RedirectToAction("Index");
            }
            return View(cONSOLIDADO);
        }

        // GET: CONSOLIDADO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CONSOLIDADO cONSOLIDADO = db.CONSOLIDADOs.Find(id);
            CONSOLIDADO cONSOLIDADO = new CONSOLIDADO_SRV().Buscar(id);
            if (cONSOLIDADO == null)
            {
                return HttpNotFound();
            }
            return View(cONSOLIDADO);
        }

        // POST: CONSOLIDADO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //CONSOLIDADO cONSOLIDADO = db.CONSOLIDADOs.Find(id);
            //db.CONSOLIDADOs.Remove(cONSOLIDADO);
            //db.SaveChanges();
            new CONSOLIDADO_SRV().Eliminar(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                new CONSOLIDADO_SRV().Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
