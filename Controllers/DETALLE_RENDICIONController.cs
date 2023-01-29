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
    public class DETALLE_RENDICIONController : Controller
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        // GET: DETALLE_RENDICION
        public ActionResult Index()
        {
            //return View(db.DETALLE_RENDICION.ToList());
            return View(new DETALLE_RENDICION_SRV().Listar());
        }

        // GET: DETALLE_RENDICION/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //DETALLE_RENDICION dETALLE_RENDICION = db.DETALLE_RENDICION.Find(id);
            DETALLE_RENDICION dETALLE_RENDICION = new DETALLE_RENDICION_SRV().Buscar(id);
            if (dETALLE_RENDICION == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_RENDICION);
        }

        // GET: DETALLE_RENDICION/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DETALLE_RENDICION/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE_ORGANIZACION,CODIGO,MONTO")] DETALLE_RENDICION dETALLE_RENDICION)
        {
            if (ModelState.IsValid)
            {
                //db.DETALLE_RENDICION.Add(dETALLE_RENDICION);
                //db.SaveChanges();
                new DETALLE_RENDICION_SRV().Agregar(dETALLE_RENDICION);
                return RedirectToAction("Index");
            }

            return View(dETALLE_RENDICION);
        }

        // GET: DETALLE_RENDICION/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //DETALLE_RENDICION dETALLE_RENDICION = db.DETALLE_RENDICION.Find(id);
            DETALLE_RENDICION dETALLE_RENDICION = new DETALLE_RENDICION_SRV().Buscar(id);
            if (dETALLE_RENDICION == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_RENDICION);
        }

        // POST: DETALLE_RENDICION/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE_ORGANIZACION,CODIGO,MONTO")] DETALLE_RENDICION dETALLE_RENDICION)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(dETALLE_RENDICION).State = EntityState.Modified;
                //db.SaveChanges();
                new DETALLE_RENDICION_SRV().Editar(dETALLE_RENDICION);
                return RedirectToAction("Index");
            }
            return View(dETALLE_RENDICION);
        }

        // GET: DETALLE_RENDICION/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //DETALLE_RENDICION dETALLE_RENDICION = db.DETALLE_RENDICION.Find(id);
            DETALLE_RENDICION dETALLE_RENDICION = new DETALLE_RENDICION_SRV().Buscar(id);
            if (dETALLE_RENDICION == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_RENDICION);
        }

        // POST: DETALLE_RENDICION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //DETALLE_RENDICION dETALLE_RENDICION = db.DETALLE_RENDICION.Find(id);
            //db.DETALLE_RENDICION.Remove(dETALLE_RENDICION);
            //db.SaveChanges();
            new DETALLE_RENDICION_SRV().Eliminar(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                new DETALLE_RENDICION_SRV().Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
