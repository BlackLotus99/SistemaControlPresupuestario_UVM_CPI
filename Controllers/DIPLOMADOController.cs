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
    public class DIPLOMADOController : Controller
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        // GET: DIPLOMADO
        public ActionResult Index()
        {
            //var dIPLOMADOes = db.DIPLOMADOs.Include(d => d.CONSOLIDADO);
            //return View(dIPLOMADOes.ToList());
            return View(new DIPLOMADO_SRV().Listar());
        }

        // GET: DIPLOMADO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //DIPLOMADO dIPLOMADO = db.DIPLOMADOs.Find(id);
            DIPLOMADO dIPLOMADO = new DIPLOMADO_SRV().Buscar(id);
            if (dIPLOMADO == null)
            {
                return HttpNotFound();
            }
            return View(dIPLOMADO);
        }

        // GET: DIPLOMADO/Create
        public ActionResult Create()
        {
            ViewBag.CONSOLIDADOID = new SelectList(db.CONSOLIDADOs, "ID", "MONTO");
            return View();
        }

        // POST: DIPLOMADO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ACTIVITY_CODE,CONSOLIDADOID,ESTADO,NOMBRE,U_EXPLOTACION,DEPARTAMENTO,PROD_TITULO,DISCIPLINA")] DIPLOMADO dIPLOMADO)
        {
            if (ModelState.IsValid)
            {
                //db.DIPLOMADOs.Add(dIPLOMADO);
                //db.SaveChanges();
                new DIPLOMADO_SRV().Agregar(dIPLOMADO);
                return RedirectToAction("Index");
            }

            ViewBag.CONSOLIDADOID = new SelectList(db.CONSOLIDADOs, "ID", "MONTO", dIPLOMADO.CONSOLIDADOID);
            return View(dIPLOMADO);
        }

        // GET: DIPLOMADO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //DIPLOMADO dIPLOMADO = db.DIPLOMADOs.Find(id);
            DIPLOMADO dIPLOMADO = new DIPLOMADO_SRV().Buscar(id);
            if (dIPLOMADO == null)
            {
                return HttpNotFound();
            }
            ViewBag.CONSOLIDADOID = new SelectList(db.CONSOLIDADOs, "ID", "MONTO", dIPLOMADO.CONSOLIDADOID);
            return View(dIPLOMADO);
        }

        // POST: DIPLOMADO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ACTIVITY_CODE,CONSOLIDADOID,ESTADO,NOMBRE,U_EXPLOTACION,DEPARTAMENTO,PROD_TITULO,DISCIPLINA")] DIPLOMADO dIPLOMADO)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(dIPLOMADO).State = EntityState.Modified;
                //db.SaveChanges();
                new DIPLOMADO_SRV().Editar(dIPLOMADO);
                return RedirectToAction("Index");
            }
            ViewBag.CONSOLIDADOID = new SelectList(db.CONSOLIDADOs, "ID", "MONTO", dIPLOMADO.CONSOLIDADOID);
            return View(dIPLOMADO);
        }

        // GET: DIPLOMADO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //DIPLOMADO dIPLOMADO = db.DIPLOMADOs.Find(id);
            DIPLOMADO dIPLOMADO = new DIPLOMADO_SRV().Buscar(id);
            if (dIPLOMADO == null)
            {
                return HttpNotFound();
            }
            return View(dIPLOMADO);
        }

        // POST: DIPLOMADO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //DIPLOMADO dIPLOMADO = db.DIPLOMADOs.Find(id);
            //db.DIPLOMADOs.Remove(dIPLOMADO);
            //db.SaveChanges();
            new DIPLOMADO_SRV().Eliminar(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                new DIPLOMADO_SRV().Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
