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
    public class ROLController : Controller
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        // GET: ROL
        public ActionResult Index()
        {
            //return View(db.ROLes.ToList());
            return View(new ROL_SRV().Listar());
        }

        // GET: ROL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ROL rOL = db.ROLes.Find(id);
            ROL rOL = new ROL_SRV().Buscar(id);
            if (rOL == null)
            {
                return HttpNotFound();
            }
            return View(rOL);
        }

        // GET: ROL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ROL/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ESTADO,NOMBRE_ROL")] ROL rOL)
        {
            if (ModelState.IsValid)
            {
                //db.ROLes.Add(rOL);
                //db.SaveChanges();
                new ROL_SRV().Agregar(rOL);
                return RedirectToAction("Index");
            }

            return View(rOL);
        }

        // GET: ROL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ROL rOL = db.ROLes.Find(id);
            ROL rOL = new ROL_SRV().Buscar(id);
            if (rOL == null)
            {
                return HttpNotFound();
            }
            return View(rOL);
        }

        // POST: ROL/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ESTADO,NOMBRE_ROL")] ROL rOL)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(rOL).State = EntityState.Modified;
                //db.SaveChanges();
                new ROL_SRV().Editar(rOL);
                return RedirectToAction("Index");
            }
            return View(rOL);
        }

        // GET: ROL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ROL rOL = db.ROLes.Find(id);
            ROL rOL = new ROL_SRV().Buscar(id);
            if (rOL == null)
            {
                return HttpNotFound();
            }
            return View(rOL);
        }

        // POST: ROL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //ROL rOL = db.ROLes.Find(id);
            //db.ROLes.Remove(rOL);
            //db.SaveChanges();
            new ROL_SRV().Eliminar(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                new ROL_SRV().Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
