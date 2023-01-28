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
    public class CAPEXController : Controller
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        // GET: CAPEX
        public ActionResult Index()
        {
            //var cAPEXes = db.CAPEXes.Include(c => c.PERSONA_JURIDICA);
            //return View(cAPEXes.ToList());
            return View(new CAPEX_SRV().Listar());
        }

        // GET: CAPEX/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CAPEX cAPEX = db.CAPEXes.Find(id);
            CAPEX cAPEX = new CAPEX_SRV().Buscar(id);
            if (cAPEX == null)
            {
                return HttpNotFound();
            }
            return View(cAPEX);
        }

        // GET: CAPEX/Create
        public ActionResult Create()
        {
            ViewBag.PERSONA_JURIDICAID = new SelectList(db.PERSONA_JURIDICAs, "ID", "NOMBRE");
            return View();
        }

        // POST: CAPEX/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ESTADO,DETALLE,RECEPCION,VALIDACION,PERSONA_JURIDICAID")] CAPEX cAPEX)
        {
            if (ModelState.IsValid)
            {
                //db.CAPEXes.Add(cAPEX);
                //db.SaveChanges();
                new CAPEX_SRV().Agregar(cAPEX);
                return RedirectToAction("Index");
            }

            ViewBag.PERSONA_JURIDICAID = new SelectList(db.PERSONA_JURIDICAs, "ID", "NOMBRE", cAPEX.PERSONA_JURIDICAID);
            return View(cAPEX);
        }

        // GET: CAPEX/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CAPEX cAPEX = db.CAPEXes.Find(id);
            CAPEX cAPEX = new CAPEX_SRV().Buscar(id);
            if (cAPEX == null)
            {
                return HttpNotFound();
            }
            ViewBag.PERSONA_JURIDICAID = new SelectList(db.PERSONA_JURIDICAs, "ID", "NOMBRE", cAPEX.PERSONA_JURIDICAID);
            return View(cAPEX);
        }

        // POST: CAPEX/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ESTADO,DETALLE,RECEPCION,VALIDACION,PERSONA_JURIDICAID")] CAPEX cAPEX)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(cAPEX).State = EntityState.Modified;
                //db.SaveChanges();
                new CAPEX_SRV().Editar(cAPEX);
                return RedirectToAction("Index");
            }
            ViewBag.PERSONA_JURIDICAID = new SelectList(db.PERSONA_JURIDICAs, "ID", "NOMBRE", cAPEX.PERSONA_JURIDICAID);
            return View(cAPEX);
        }

        // GET: CAPEX/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CAPEX cAPEX = db.CAPEXes.Find(id);
            CAPEX cAPEX = new CAPEX_SRV().Buscar(id);
            if (cAPEX == null)
            {
                return HttpNotFound();
            }
            return View(cAPEX);
        }

        // POST: CAPEX/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //CAPEX cAPEX = db.CAPEXes.Find(id);
            //db.CAPEXes.Remove(cAPEX);
            //db.SaveChanges();
            new CAPEX_SRV().Eliminar(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                new CAPEX_SRV().Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
