using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sistema_UVM_Control_Presupuestario;

namespace Sistema_UVM_Control_Presupuestario.Controllers
{
    public class SALIDA_TERRENOController : Controller
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        // GET: SALIDA_TERRENO
        public ActionResult Index()
        {
            return View(db.SALIDA_TERRENOs.ToList());
        }

        // GET: SALIDA_TERRENO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALIDA_TERRENO sALIDA_TERRENO = db.SALIDA_TERRENOs.Find(id);
            if (sALIDA_TERRENO == null)
            {
                return HttpNotFound();
            }
            return View(sALIDA_TERRENO);
        }

        // GET: SALIDA_TERRENO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SALIDA_TERRENO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ESTADO,TIPO_SALIDA,UBICACION,CANTIDAD_ALUMNOS")] SALIDA_TERRENO sALIDA_TERRENO)
        {
            if (ModelState.IsValid)
            {
                db.SALIDA_TERRENOs.Add(sALIDA_TERRENO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sALIDA_TERRENO);
        }

        // GET: SALIDA_TERRENO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALIDA_TERRENO sALIDA_TERRENO = db.SALIDA_TERRENOs.Find(id);
            if (sALIDA_TERRENO == null)
            {
                return HttpNotFound();
            }
            return View(sALIDA_TERRENO);
        }

        // POST: SALIDA_TERRENO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ESTADO,TIPO_SALIDA,UBICACION,CANTIDAD_ALUMNOS")] SALIDA_TERRENO sALIDA_TERRENO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sALIDA_TERRENO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sALIDA_TERRENO);
        }

        // GET: SALIDA_TERRENO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALIDA_TERRENO sALIDA_TERRENO = db.SALIDA_TERRENOs.Find(id);
            if (sALIDA_TERRENO == null)
            {
                return HttpNotFound();
            }
            return View(sALIDA_TERRENO);
        }

        // POST: SALIDA_TERRENO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SALIDA_TERRENO sALIDA_TERRENO = db.SALIDA_TERRENOs.Find(id);
            db.SALIDA_TERRENOs.Remove(sALIDA_TERRENO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
