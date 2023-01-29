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
    public class USUARIOController : Controller
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        // GET: USUARIO
        public ActionResult Index()
        {
            //var uSUARIOs = db.USUARIOs.Include(u => u.ROL);
            //return View(uSUARIOs.ToList());
            return View(new USUARIO_SRV().Listar());
        }

        // GET: USUARIO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //USUARIO uSUARIO = db.USUARIOs.Find(id);
            USUARIO uSUARIO = new USUARIO_SRV().Buscar(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // GET: USUARIO/Create
        public ActionResult Create()
        {
            ViewBag.ROLID = new SelectList(db.ROLes, "ID", "NOMBRE_ROL");
            return View();
        }

        // POST: USUARIO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ESTADO,ROLID,NOMBRE_USUARIO,CONTRASENA")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                //db.USUARIOs.Add(uSUARIO);
                //db.SaveChanges();
                new USUARIO_SRV().Agregar(uSUARIO);
                return RedirectToAction("Index");
            }

            ViewBag.ROLID = new SelectList(db.ROLes, "ID", "NOMBRE_ROL", uSUARIO.ROLID);
            return View(uSUARIO);
        }

        // GET: USUARIO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //USUARIO uSUARIO = db.USUARIOs.Find(id);
            USUARIO uSUARIO = new USUARIO_SRV().Buscar(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ROLID = new SelectList(db.ROLes, "ID", "NOMBRE_ROL", uSUARIO.ROLID);
            return View(uSUARIO);
        }

        // POST: USUARIO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ESTADO,ROLID,NOMBRE_USUARIO,CONTRASENA")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(uSUARIO).State = EntityState.Modified;
                //db.SaveChanges();
                new USUARIO_SRV().Editar(uSUARIO);
                return RedirectToAction("Index");
            }
            ViewBag.ROLID = new SelectList(db.ROLes, "ID", "NOMBRE_ROL", uSUARIO.ROLID);
            return View(uSUARIO);
        }

        // GET: USUARIO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //USUARIO uSUARIO = db.USUARIOs.Find(id);
            USUARIO uSUARIO = new USUARIO_SRV().Buscar(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // POST: USUARIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //USUARIO uSUARIO = db.USUARIOs.Find(id);
            //db.USUARIOs.Remove(uSUARIO);
            //db.SaveChanges();
            new USUARIO_SRV().Eliminar(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                new USUARIO_SRV().Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
